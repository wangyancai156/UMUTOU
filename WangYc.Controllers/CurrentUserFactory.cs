using System.Linq;
using System.Text;
using System.Web;


namespace WangYc.Controllers {
    public class CurrentUserFactory {

        public static CurrentUser GetCurrentUser() {

            CurrentUser result = null;

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("JKUser")) {
                result = new CurrentUser();
                result.Id = HttpContext.Current.Request.Cookies["JKUser"].Values["userId"];
                result.ChineseName = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["JKUser"].Values["username"], Encoding.GetEncoding("utf-8"));
            }
            else {
                result = new CurrentUser();
                result.Id = "LCT";
                result.ChineseName = "管理员";
            }

            return result;
        }

        public static void SetCurrentUser(string domainName, string userName) {

            //AccountController account = new AccountController(ObjectFactory.GetInstance<IUsersService>());
            //UsersView employee = account.FindUsersBy(userName);

            //HttpCookie cookie = new HttpCookie("JKUser");
            //cookie.Values.Add("userId", employee.Id);
            //cookie.Values.Add("userName", userName);
            //cookie.Expires = DateTime.Now.AddDays(7);
            //HttpContext.Current.Response.Cookies.Add(cookie);

            #region MyRegion
            //cookie.Expires = DateTime.Now.AddDays(7);
            //cookie["userId"] = employee.Id;
            //cookie["userName"] = userName;

            //HttpContext.Current.Response.Cookies.Add(cookie); 
            #endregion
        }
    }


    public class CurrentUser {

        public string Id { get; set; }
        public string ChineseName { get; set; }
        public string LoginName { get; set; }
        public string DepartmentId { get; set; }

        //public IList<MenuItem> GetSDPermissions(IEmployeeService employeeService) {

        //    IList<MenuItem> result;
        //    IEnumerable<JK.Common.Model.Authorization.AuthorizationObject> authObjects = employeeService.GetSDPermssion(this.Id);
        //    result = authObjects.OrderBy(x => x.DisplaySequence).Select(x => new MenuItem() { Id = x.Id, MenuItemName = x.Name, TargetUrl = x.TargetUrl, ParentId = x.ParentId }).ToList();
        //    return result.DistinctBy(r => r.Id).ToList();//针对Id进行去重。避免，当在EPPermission表中对A员工多次设置B权限时，A员工的界面出现多个B权限相关界面的菜单项
        //}
    }
}
