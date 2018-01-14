using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

namespace WangYc.Repository.NHibernate.Repositories
{
    public abstract class Repository<T, TEntityKey> where T : IAggregateRoot
    {

        /* TODO: 这个IUnitOfWork实际上也根本没有用到，Why?
         * Repository应该使用UnitOfWork来注册/提交修改，但是NHibernate的Session相当于一个UnitOfWork，所以此Repository
         * 中直接使用了Session，没有用到uow。实际上，我们也写了NH版本的uow,即NHUnitOfWork(封装了NHibernate的Session）
         * 此Repository中使用NHUnitOfWork的做法更标准（只是还需要进行Ioc配置），这样其他的框架中没有类似Session的概念时，
         * 可以自行实现UnitOfWork（这也是Infrasturce.UnitOfWork中IUnitOfWork存在的理由）
         * 另外NHibernate中的Session好像是UnitOfWork和Repository的综合体（EntityFrameWork中的DBContext也是），既有uow的
         * 注册/提交功能，也有Repository的查找/修改功能
         */
        private WangYc.Core.Infrastructure.UnitOfWork.IUnitOfWork _uow;

        public Repository(WangYc.Core.Infrastructure.UnitOfWork.IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {

            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public T FindBy(TEntityKey id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(id);
        }

        public IEnumerable<T> FindAll()
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return criteriaQuery.SetMaxResults(count).SetFirstResult((index - 1) * count).List<T>();
        }

        public int CountAll()
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return (int)criteriaQuery.SetProjection(Projections.RowCount()).List()[0];
        }

        public IEnumerable<T> FindBy(Query query)
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);
            QueryTranslator queryTranslator = CreateQueryTranslator(query);
            //query.TranslateIntoNHQuery<T>(criteriaQuery);
            queryTranslator.TranslateToNHQuery(criteriaQuery);
            return criteriaQuery.List<T>();
        }

        public int CountBy(Query query)
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);
            QueryTranslator queryTranslator = CreateQueryTranslator(query);
            queryTranslator.TranslateToNHQuery(criteriaQuery);
            return (int)criteriaQuery.SetProjection(Projections.RowCount()).List()[0];
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {

            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);
            QueryTranslator queryTranslator = CreateQueryTranslator(query);
            //query.TranslateIntoNHQuery<T>(criteriaQuery);
            queryTranslator.TranslateToNHQuery(criteriaQuery);
            return criteriaQuery.SetMaxResults(count).SetFirstResult((index - 1) * count).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteriaQuery)
        {
        }

        public virtual QueryTranslator CreateQueryTranslator(Query query)
        {
            return new QueryTranslator(query);
        }

    }
}
