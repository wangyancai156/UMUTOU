using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using WangYc.DAL;
using WangYc.Models;

namespace WangYc.BLL
{

    public class UsersManage
    {

       private readonly UsersService user = new UsersService();

        public DataSet GetUsers() {
            return user.GetUsers();
        }
    }
}
