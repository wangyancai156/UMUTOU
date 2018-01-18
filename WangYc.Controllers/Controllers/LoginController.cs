using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cmmooc.Information.Component.Tools.WebHelp;
using Cmmooc.Information.Component.Tools.EncryptionHelp;
using WangYc.Models.PModel;
using WangYc.Core.Common;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;

namespace WangYc.Controllers.Controllers
{
    public class LoginController : WebAppController
    {

        #region IOC
        private readonly IUsersService _usersService;

        public LoginController(IUsersService usersService)
        {
            this._usersService = usersService;
        }
        #endregion

        /// <summary>
        ///  登录界面
        /// </summary>
        /// <param name="reurl">来源地址</param>
        /// <returns></returns>
        public ActionResult Index(string reurl)
        {
            ViewBag.ReturnUrl = reurl;
            return View();
        }

        /// <summary>
        ///  登录操作
        /// </summary>
        /// <param name="uname">账号</param>
        /// <param name="upass">密码</param>
        /// <param name="vcode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string uname, string upass, string vcode)
        {
            // 基本信息校验
            if (string.IsNullOrWhiteSpace(uname))
                return Json(new ResponseResult() { StatusCode = 101, Message = "请输入用户名" });
            if (string.IsNullOrWhiteSpace(upass))
                return Json(new ResponseResult() { StatusCode = 102, Message = "请输入登录密码" });
            if (string.IsNullOrWhiteSpace(vcode))
                return Json(new ResponseResult() { StatusCode = 103, Message = "请输入验证码" });
            if (Session[CookieKeyDefine.LoginVCode.ToLower()] == null || vcode.Trim() != Session[CookieKeyDefine.LoginVCode.ToLower()].ToString())
                return Json(new ResponseResult() { StatusCode = 104, Message = "验证码输入错误" });
            // TODO：注册时，需对密码进行MD5加密
            //upass = MD5Encrypt.Encrypt(upass.Trim(), Encoding.UTF8); 
            var user = _usersService.FindUsersBy(uname, upass);
            if (user == null)
            {
                return Json(new ResponseResult() { StatusCode = 105, Message = "账号或密码错误" });
            }
            // 清空验证码session，避免资源浪费
            Session.Remove(CookieKeyDefine.LoginVCode);
            // 更新登录时间
            _usersService.UpdateLastLoginTime(user.Id);
            // 保存登录信息到cookie中
            SaveLoginCookie(user);
            var result = new ResponseResult() { StatusCode = 100, Message = "登录成功" };
            return Json(result);
        }

        /// <summary>
        ///  退出登录，返回到登录界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            RemoveLoginUserCookie();
            return RedirectToAction("index");
        }
    }
}
