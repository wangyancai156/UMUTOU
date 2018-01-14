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

namespace WangYc.Controllers.Controllers.Account {
    public class AccountController : Controller {

        private readonly IUsersService employeeService;

        public AccountController(IUsersService employeeService) {

            this.employeeService = employeeService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string domainName, string userName, string password, string returnUrl) {

            WindowsIdentity userIdentiy = ActiveDirectoryHelper.GetWindowsIdentity(domainName, userName, password);
            if (userIdentiy != null) {

                string userData = domainName + "|" + userName + "|" + password;
                //BinaryFormatter formatter = new BinaryFormatter();
                //MemoryStream stream = new MemoryStream();
                //formatter.Serialize(stream, userIdentiy);
                //stream.Position = 0;
                //StreamReader reader = new StreamReader(stream);
                //userData = reader.ReadToEnd();
                //stream.Close();

                HttpCookie cookie = CreateFormAuthenticationCustomeCookie(userIdentiy.Name, userData);

                // 写登录Cookie
                Response.Cookies.Remove(cookie.Name);
                Response.Cookies.Add(cookie);

                // 重定向回验证前访问的界面
                //Response.Redirect(FormsAuthentication.GetRedirectUrl(userIdentiy.Name, true));
                return Redirect(returnUrl);
            }
            else {
                return View();
            }

        }

        private HttpCookie CreateFormAuthenticationCustomeCookie(string name, string userData) {

            // 1.创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, name, DateTime.Now, DateTime.Now.AddHours(4), true, userData);

            // 2.加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);

            // 3.根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = DateTime.Now.AddHours(4);

            return cookie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UsersView GetEmployee(string domainName, string userName) {

            return employeeService.FindUsersBy(userName);
        }
    }
}
