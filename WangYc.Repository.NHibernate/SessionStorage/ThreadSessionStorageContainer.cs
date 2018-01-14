using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WangYc.Repository.NHibernate.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {

        private static readonly Hashtable nhSessions = new Hashtable();

        public ISession GetCurrentSession()
        {
            ISession nhSession = null;
            if (nhSessions.Contains(GetThreadName()))
                nhSession = (ISession)nhSessions[GetThreadName()];
            return nhSession;
        }

        public void Store(ISession session)
        {
            if (nhSessions.Contains(GetThreadName()))
                nhSessions[GetThreadName()] = session;
            else
                nhSessions.Add(GetThreadName(), session);
        }

        private static string GetThreadName()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "MainThread";
            }
            return Thread.CurrentThread.Name;
        }
    }
}
