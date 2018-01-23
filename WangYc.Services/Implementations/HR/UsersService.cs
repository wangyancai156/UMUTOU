using System;
using System.Collections.Generic;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using System.Linq;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Services.Implementations.HR {
    public class UsersService : IUsersService {
        private readonly IUsersRepository _usersRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _uow;

        public UsersService(IUsersRepository usersRepository, IOrganizationRepository organizationRepository, IUnitOfWork uow) {
            this._usersRepository = usersRepository;
            this._organizationRepository = organizationRepository;
            this._uow = uow;

        }

        public IEnumerable<UsersView> GetUsersView() {

            IEnumerable<Users> users = _usersRepository.FindAll();
            return users.ConvertToUsersView();
        }


        #region 查找

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers() {
            IEnumerable<Users> users = _usersRepository.FindAll();

            return users;
        }

        public Users FindBy(string userId) {

            Users user = _usersRepository.FindBy(userId);
            return user;
        }

        public UsersView FindUsersBy(string userid) {
            Users user = _usersRepository.FindBy(userid);
            //Query query = new Query();
            //query.Add(Criterion.Create<Users>(c=>c.UserName,userid,CriteriaOperator.Equal));
            //IEnumerable<Users> user = _usersRepository.FindBy(query);
            return user.ConvertToUsersView();
        }

        /// <summary>
        ///  用户登录时查询
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public UsersView FindUsersBy(string username, string pass)
        {
            Query query = new Query();
            query.Add(Criterion.Create<Users>(c => c.UserName, username, CriteriaOperator.Equal));
            query.Add(Criterion.Create<Users>(c => c.UserPwd, pass, CriteriaOperator.Equal));
            query.QueryOperator = QueryOperator.And;
            var users = _usersRepository.FindBy(query).ConvertToUsersView();
            return users.FirstOrDefault();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="userid"></param>
        public void DeleteUsers(string userid) {
            Users user = FindBy(userid);
            _usersRepository.Remove(user);
            _uow.Commit();
        }

        #endregion

        #region 添加
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public void InsertUsers(AddUsersRequest request) {

            Organization organization = this._organizationRepository.FindBy(request.Organizationid);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            Users user = new Users(organization, request.Id, request.UserName, request.UserPwd, request.Telephone);
            _usersRepository.Add(user);
            _uow.Commit();
        }
        #endregion

        #region 修改
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUsers(AddUsersRequest request) {

            Users user = this._usersRepository.FindBy(request.Id);
            if (user == null) {
                throw new EntityIsInvalidException<string>(user.Id.ToString());
            }

            Organization organization = this._organizationRepository.FindBy(request.Organizationid);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            user.Organization = organization;
            user.Telephone = request.Telephone;
            user.UserName = request.UserName;
            user.UserPwd = request.UserPwd;
           
            _uow.Commit();
        }

        /// <summary>
        ///  更新最后登录时间
        /// </summary>
        /// <param name="userId">用户编号</param>
        public void UpdateLastLoginTime(string userId)
        {
            Users user = this._usersRepository.FindBy(userId);
            if (user == null)
            {
                throw new EntityIsInvalidException<string>(user.Id.ToString());
            }
            user.LastSignTime = DateTime.Now;
            _usersRepository.Save(user);
            _uow.Commit();
        }

        #endregion

    }
}
