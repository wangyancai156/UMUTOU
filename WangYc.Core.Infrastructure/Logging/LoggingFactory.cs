using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Logging {
    public class LoggingFactory {
        //日志工厂
        private static ILogger _logger;

        public static void InitializeLogFactory(ILogger logger) {
            _logger = logger;
        }

        public static ILogger GetLogger() {
            return _logger;
        }

    }
}
