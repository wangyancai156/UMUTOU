using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using WangYc.Services.Interfaces.HR;
using System.Security.Principal;
using WangYc.Core.Infrastructure.Security;
using System.Web;
using System.Web.Security;
using WangYc.Services.ViewModels.HR;
using WangYc.Models.PModel;
using WangYc.Core.Infrastructure.Account;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Core.Infrastructure.Configuration;

namespace WangYc.Controllers.Controllers.Account {
    public class AccountController:Controller {

        private readonly IUsersService _usersService;
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IAuthenticationService _authenticationService;
        

        public AccountController(IUsersService usersService, ICookieStorageService cookieStorageService, IAuthenticationService authenticationService) {

            this._usersService = usersService;
            this._cookieStorageService = cookieStorageService;
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {

            ViewBag.ReturnUrl = returnUrl;
            try {

                string cookieValue = this._cookieStorageService.Retrieve(FormsAuthentication.FormsCookieName);
                FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);
                if (tickets != null && tickets.Name != null || tickets.Expired) {
                    if (string.IsNullOrEmpty(returnUrl)) {
                        returnUrl = "/BW/InOutBound/Index";
                    }
                    return Redirect(returnUrl);
                }

            }
            catch {
            }
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="domainName">域名</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="returnUrl">请求页面</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string domainName, string loginName, string password, string vcode, string returnUrl) {
 
            //Windows身份验证,
            //WindowsIdentity userIdentiy = ActiveDirectoryHelper.GetWindowsIdentity(domainName, userName, password);
            //Form身份验证
            // 基本信息校验
            if (string.IsNullOrWhiteSpace(loginName))
                return Json(new ResponseResult() { StatusCode = 101, Message = "请输入用户名" });
            if (string.IsNullOrWhiteSpace(password))
                return Json(new ResponseResult() { StatusCode = 102, Message = "请输入登录密码" });
            if (string.IsNullOrWhiteSpace(vcode))
                return Json(new ResponseResult() { StatusCode = 103, Message = "请输入验证码" });
            if (Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode] == null || vcode.Trim() != Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode].ToString())
                return Json(new ResponseResult() { StatusCode = 104, Message = "验证码输入错误" });

            UsersView user = this._usersService.FindUsersBy(loginName);
            if (user != null) {

                if (user.UserPwd == password) {

                    string userData = domainName + "|" + loginName + "|" + password;
                    // 添加认证
                    this._authenticationService.AddFormAuthenticationCustomeCookie(user.Id, userData);
                    // 更新登录时间
                    this._usersService.UpdateLastLoginTime(user.Id);
                    // 重定向回验证前访问的界面
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(userIdentiy.Name, true));
                    if (string.IsNullOrEmpty(returnUrl)) {
                        returnUrl = "/BW/InOutBound/Index";
                    }
                    return Redirect(returnUrl);

                }
                else {
                    return View();
                    //return Json(new ResponseResult() { StatusCode = 102, Message = "密码错误" });
                }

                // 清空验证码session，避免资源浪费
                Session.Remove(ApplicationSettingsFactory.GetApplicationSettings().VerificationCode);


            }
            else {
                //return Json(new ResponseResult() { StatusCode = 102, Message = "用户名错误" });
            }
            //return Json(new ResponseResult() { StatusCode = 100, Message = "登录成功" });
            return View();
        }

        public UsersView FindUsersBy(string userName) {

            return this._usersService.FindUsersBy(userName);
        }
    }
}