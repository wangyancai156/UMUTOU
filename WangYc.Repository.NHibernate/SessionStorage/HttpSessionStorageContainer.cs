using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WangYc.Repository.NHibernate.SessionStorage
{
    public class HttpSessionStorageContainer : ISessionStorageContainer
    {

        private string sessionKey = "NHSession";

        public ISession GetCurrentSession()
        {

            ISession nhSession = null;
            if (HttpContext.Current.Items.Contains(sessionKey))
                nhSession = (ISession)HttpContext.Current.Items[sessionKey];
            return nhSession;
        }

        public void Store(ISession session)
        {
            if (HttpContext.Current.Items.Contains(sessionKey))
                HttpContext.Current.Items[sessionKey] = session;
            else
                HttpContext.Current.Items.Add(sessionKey, session);
        }
    }
}
