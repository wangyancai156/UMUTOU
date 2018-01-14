using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using WangYc.Core.Infrastructure.Configuration;
namespace WangYc.Core.Infrastructure.Logging {
    public class Log4NetAdapter : ILogger {

        private readonly log4net.ILog log;

        public Log4NetAdapter() {
            XmlConfigurator.Configure();
            log = LogManager
            .GetLogger(ApplicationSettingsFactory.GetApplicationSettings()
            .LoggerName);
        }


        public bool IsErrorEnabled { get { return log.IsErrorEnabled; } }
        public bool IsFatalEnabled { get { return log.IsFatalEnabled; } }
        public bool IsDebugEnabled { get { return log.IsDebugEnabled; } }
        public bool IsInfoEnabled { get { return log.IsInfoEnabled; } }
        public bool IsWarnEnabled { get { return log.IsWarnEnabled; } }

        public void Error(object message) {
            if (IsErrorEnabled)
                log.Error(message);
        }
        public void Error(object message, Exception exception) {
            if (IsErrorEnabled)
                log.Error(message, exception);
        }
        public void ErrorFormat(string format, params object[] args) {
            if (IsErrorEnabled)
                log.ErrorFormat(format, args);
        }

        public void Fatal(object message) {
            if (IsFatalEnabled)
                log.Fatal(message);
        }
        public void Fatal(object message, Exception exception) {
            if (IsFatalEnabled)
                log.Fatal(message, exception);
        }

        public void Debug(object message) {
            if (IsDebugEnabled)
                log.Debug(message);
        }
        public void Debug(object message, Exception exception) {
            if (IsDebugEnabled)
                log.Debug(message, exception);
        }
        public void DebugFormat(string format, params object[] args) {
            if (IsDebugEnabled)
                log.DebugFormat(format, args);
        }

        public void Info(object message) {
            if (IsInfoEnabled)
                log.Info(message);
        }
        public void Info(object message, Exception exception) {
            if (IsInfoEnabled)
                log.Info(message, exception);
        }
        public void InfoFormat(string format, params object[] args) {
            if (IsInfoEnabled)
                log.InfoFormat(format, args);
        }
        public void Log(string message) {
            log.Info(message);
        }


        public void Warn(object message) {
            if (IsWarnEnabled)
                log.Warn(message);
        }
        public void Warn(object message, Exception exception) {
            if (IsWarnEnabled)
                log.Warn(message, exception);
        }
        public void WarnFormat(string format, params object[] args) {
            if (IsWarnEnabled)
                log.WarnFormat(format, args);
        }

    }

}
