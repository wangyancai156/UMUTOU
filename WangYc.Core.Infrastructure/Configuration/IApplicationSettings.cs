using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Configuration {
    public interface IApplicationSettings {
        /// <summary>
        /// 日志名称
        /// </summary>
        string LoggerName { get; }
        /// <summary>
        /// 验证码名称
        /// </summary>
        string VerificationCode { get; }
        /// <summary>
        /// 登录页面
        /// </summary>
        string LoginPage { get; }
    }
}
