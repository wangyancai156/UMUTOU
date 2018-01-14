using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using WangYc.Models;
using WangYc.DBUtility;

namespace WangYc.DAL
{
    public class UsersService
    {

        public DataSet GetUsers() {
            string sql = " select * from wangyc.dbo.users ";
            return DbHelperSQL.Query(sql);

            IList<Users> list = new List<Users>();
            

            
        }
    }
}
