using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Account {
    public class AuthenticationFactory {

        private static IAuthenticationService _authenticationService;

        public static void InitializeAuthenticationFactory(IAuthenticationService authenticationServiccs) {

           _authenticationService = authenticationServiccs;
        }

        public static IAuthenticationService Authentication() {
            return _authenticationService;
        }

    }
}
