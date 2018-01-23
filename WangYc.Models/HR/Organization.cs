using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    public class Organization : EntityBase<int>, IAggregateRoot {

        #region 属性

        public  Organization() { }

        public  Organization( Organization parent, string name, string descriptin, int level ) {

            this.Name = name;
            this.Descriptin = descriptin;
            this.Level = level;
            this.CreateDate = DateTime.Now;
            this.Parent = parent;
 
        }
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual Organization Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public virtual IList<Organization> Child { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Descriptin { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public virtual int Level { get; set; }


        #endregion

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual Organization AddChild(string name, string descriptin) {

            Organization organization = new Organization(this, name, descriptin, this.Level + 1);
            if (Child == null) {
                Child = new List<Organization>();
                Child.Add(organization);
            }
            else {
                Child.Add(organization);
            }

            return organization;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual void UpdateOrganization(string name, string descriptin) {

            this.Name = name;
            this.Descriptin = descriptin;
        }


        #endregion

        protected override void Validate() {
            throw new NotImplementedException();
        }

    }
}
