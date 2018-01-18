using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Common
{
    public class CookieKeyDefine
    {

        /// <summary>
        ///  网站加密密钥
        /// </summary>
        public static string WebEncryptionKey = "UMUTOU_ERP";

        /// <summary>
        ///  登录验证码
        /// </summary>
        public static string LoginVCode = "SHARP_LOGIN";

        /// <summary>
        ///  登录后的账号key
        /// </summary>
        public static string LoginUserInfo = "SHARP_LOGINUSER";

        /// <summary>
        ///  登录用户的id
        /// </summary>
        public static string LoginUserId = "SHARP_LOGINUSERID";

        /// <summary>
        ///  登录用户姓名
        /// </summary>
        public static string LoginUserName = "SHARP_LOGINUSERNAME";
    }
}
