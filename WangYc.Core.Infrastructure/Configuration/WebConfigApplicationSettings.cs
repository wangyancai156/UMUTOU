﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WangYc.Core.Infrastructure.Configuration {

    public class WebConfigApplicationSettings : IApplicationSettings {

        public string LoggerName {
            get { return ConfigurationManager.AppSettings["JKLoggerName"]; }
        }

    }
}