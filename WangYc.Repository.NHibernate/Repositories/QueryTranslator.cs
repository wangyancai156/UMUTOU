using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;

namespace WangYc.Repository.NHibernate.Repositories
{
    public class QueryTranslator
    {

        private Query query;

        public QueryTranslator(Query query)
        {
            this.query = query;
            this.IndirectProperties = new string[] { "" };
        }

        public virtual string[] IndirectProperties { get; set; }

        public ICriteria TranslateToNHQuery(ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);
            if (query.OrderByProperty != null)
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName, !query.OrderByProperty.Desc));
            return criteria;
        }

        private void BuildQueryFrom(Query query, ICriteria criteria)
        {

            IList<ICriterion> criterions = new List<ICriterion>();

            if (query.Criteria != null)
            {

                foreach (Criterion c in query.Criteria)
                {

                    //处理查询属性中还有.的情况，在这种情况下，表示查询条件并非本对象的直接属性，而是
                    //相关对象的属性，如使用包装所属产品的属性查询对应的包装时，则查询属性为package.Product.OriginalId="A0040"
                    int lastPositionOfDot = c.PropertyName.LastIndexOf(".");
                    if (lastPositionOfDot > 0)
                    {
                        TranslateCascadeToNHCriterion(c, criteria);
                    }
                    else
                    {
                        ICriterion criterion;
                        if (IndirectProperties.Contains(c.PropertyName.ToLower()))
                        {
                            criterion = GenerateSqlCriterion(c);
                        }
                        else
                        {
                            criterion = TranslateToNHCriterion(c);
                        }
                        criterions.Add(criterion);
                    }
                }

                if (query.QueryOperator == QueryOperator.And)
                {
                    Conjunction andSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        andSubQuery.Add(criterion);
                    }
                    criteria.Add(andSubQuery);
                }
                else
                {
                    Disjunction orSubQuery = Expression.Disjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        orSubQuery.Add(criterion);
                    }
                    criteria.Add(orSubQuery);
                }

                foreach (Query sub in query.SubQueries)
                {
                    BuildQueryFrom(sub, criteria);
                }
            }
        }

        /// <summary>
        /// 处理查询属性中还有.的情况，在这种情况下，表示查询条件并非本对象的直接属性，而是
        /// 相关对象的属性，如使用包装所属产品的属性查询对应的包装时，则查询属性为package.Product.OriginalId="A0040"
        /// </summary>
        /// <param name="criterion"></param>
        /// <param name="criteria"></param>
        private void TranslateCascadeToNHCriterion(Criterion criterion, ICriteria criteria)
        {

            int firstPositionOfDot = criterion.PropertyName.IndexOf(".");
            string subCriteriaPath = criterion.PropertyName.Substring(0, firstPositionOfDot);
            Criterion subCriterion = null;
            switch (criterion.CriteriaOperator)
            {
                case CriteriaOperator.InOfInt32:
                case CriteriaOperator.NotInOfInt32:
                case CriteriaOperator.InOfString:
                case CriteriaOperator.NotInOfString:
                    if (criterion.Values != null && criterion.Values.Count > 0)
                    {
                        subCriterion = new Criterion(criterion.PropertyName.Substring(firstPositionOfDot + 1), criterion.Values, criterion.CriteriaOperator);
                    }
                    break;
                default:
                    subCriterion = new Criterion(criterion.PropertyName.Substring(firstPositionOfDot + 1), criterion.Value, criterion.CriteriaOperator);
                    break;
            }

            if (subCriterion == null)
            {
                return;
            }
            ICriteria subCriteria = criteria.GetCriteriaByPath(subCriteriaPath);
            if (subCriteria == null)
            {
                subCriteria = criteria.CreateCriteria(subCriteriaPath);
            }

            if (subCriterion.PropertyName.IndexOf(".") > 0)
            {
                TranslateCascadeToNHCriterion(subCriterion, subCriteria);
            }
            else
            {
                ICriterion subNHCriterion = TranslateToNHCriterion(subCriterion);
                subCriteria.Add(subNHCriterion);
            }
        }

        private ICriterion TranslateToNHCriterion(Criterion criterion)
        {

            ICriterion nhCriterion;
            switch (criterion.CriteriaOperator)
            {
                case CriteriaOperator.Equal:
                    nhCriterion = Expression.Eq(criterion.PropertyName, criterion.Value);
                    break;
                case CriteriaOperator.NotEqual:
                    nhCriterion = Expression.Not(Expression.Eq(criterion.PropertyName, criterion.Value));
                    break;
                case CriteriaOperator.LesserThanOrEqual:
                    nhCriterion = Expression.Le(criterion.PropertyName, criterion.Value);
                    break;
                case CriteriaOperator.GreaterThanOrEqual:
                    nhCriterion = Expression.Ge(criterion.PropertyName, criterion.Value);
                    break;
                case CriteriaOperator.Like:
                    nhCriterion = Expression.Like(criterion.PropertyName, criterion.Value);
                    break;
                case CriteriaOperator.IsNull:
                    nhCriterion = Expression.IsNull(criterion.PropertyName);
                    break;
                case CriteriaOperator.IsNotNull:
                    nhCriterion = Expression.IsNotNull(criterion.PropertyName);
                    break;
                case CriteriaOperator.InOfInt32:
                    nhCriterion = Expression.In(criterion.PropertyName, criterion.Values);
                    break;
                case CriteriaOperator.NotInOfInt32:
                    nhCriterion = Expression.Not(Expression.In(criterion.PropertyName, criterion.Values));
                    break;
                case CriteriaOperator.InOfString:
                    nhCriterion = Expression.In(criterion.PropertyName, criterion.Values);
                    break;
                case CriteriaOperator.NotInOfString:
                    nhCriterion = Expression.Not(Expression.In(criterion.PropertyName, criterion.Values));
                    break;
                default:
                    throw new ApplicationException("No operator defined");
            }
            return nhCriterion;
        }

        public virtual ICriterion GenerateSqlCriterion(Criterion criterion)
        {

            throw new ApplicationException("No operator defined");
        }


    }
}
