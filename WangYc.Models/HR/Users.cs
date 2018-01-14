using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    /// <summary>
    /// Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Users : EntityBase<string>, IAggregateRoot {
        public Users() { }
        public Users(Organization organization, string id, string username, string userpwd, string telephone) {
           
            this.Organization = organization;
            this.Id = id;
            this.UserName = username;
            this.UserPwd = userpwd;
            this.SignState = 1;
            this.Telephone = telephone;
        }


        #region Model

        public virtual Organization Organization {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserPwd {
            get;
            set;
        }


        public virtual string Telephone {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastSignTime {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual int SignState {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string TickeID {
            get;
            set;
        }

      
        #endregion Model


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}

