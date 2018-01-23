using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {

    public class Rights : EntityBase<int>, IAggregateRoot {

        #region 属性

        public Rights() { }

        public Rights(Rights parent, string name,string url, string descriptin, bool isshow, int level) {

            this.Name = name;
            this.Url = url;
            this.Descriptin = descriptin;
            this.IsShow = isshow;
            this.Level = level;
            this.CreateDate = DateTime.Now;
            this.Parent = parent;

        }
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual Rights Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public virtual IList<Rights> Child { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Url { get; set; }

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
        /// <summary>
        /// 是否显示
        /// </summary>
        public virtual bool IsShow { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual Rights AddChild(string name,string url, string descriptin, bool isshow) {

            Rights rights = new Rights(this, name, url, descriptin, isshow, this.Level + 1);
            if (Child == null) {
                Child = new List<Rights>();
                Child.Add(rights);
            }
            else {
                Child.Add(rights);
            }

            return rights;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual void UpdateRights(string name,string url, string descriptin, bool isshow) {

            this.Name = name;
            this.Descriptin = descriptin;
            this.IsShow = isshow;
            this.Url = url;
        }


        #endregion


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}
