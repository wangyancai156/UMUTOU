﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Logging {
    //日志接口
    public interface ILogger {


        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        void Error(object message);
        void Error(object message, Exception exception);
        void ErrorFormat(string format, params object[] args);

        void Fatal(object message);
        void Fatal(object message, Exception exception);

        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string format, params object[] args);

        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void Log(string message);


        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(string format, params object[] args);
    }
}
