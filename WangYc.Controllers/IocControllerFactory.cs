using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;

namespace WangYc.Controllers
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        public IContainer Container { get; set; }

        public IocControllerFactory()
        {
            Container = ObjectFactory.Container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "没有找到相关controller");
            }
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
