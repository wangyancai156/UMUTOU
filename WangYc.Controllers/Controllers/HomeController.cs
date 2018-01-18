using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WangYc.Controllers.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}
