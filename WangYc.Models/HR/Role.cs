using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    /// <summary>
    /// Roles:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public class Role : EntityBase<int>, IAggregateRoot {

        #region Model

        public Role() { }

        public Role(Organization organization, string name, string description) {

            this.Organization = organization;
            this.Name = name;
            this.Description = description;
            this.CreateDate = DateTime.Now;
                    
        }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { set; get; }
        /// <summary>
        /// 组织
        /// </summary>
        public virtual Organization Organization {
            get;
            set;
        }
        /// <summary>
        /// 权限
        /// </summary>
        public virtual IList<Rights> Rights { set; get; } 

        #endregion Model

        /// <summary>修改角色
        /// 修改角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public virtual void UpdateRole(string name, string description) {

            this.Name = name;
            this.Description = description;
        }

        /// <summary>添加权限
        /// 添加权限
        /// </summary>
        /// <param name="rights"></param>
        public virtual void AddRights(IEnumerable<Rights> rightsList) {

            if (Rights == null) {
                Rights = new List<Rights>();
            }

            foreach (Rights rights in rightsList) {
                Rights.Add(rights);
            }
        }


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}

