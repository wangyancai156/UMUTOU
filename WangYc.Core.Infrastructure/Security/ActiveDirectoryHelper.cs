using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace WangYc.Core.Infrastructure.Security {
    public static class ActiveDirectoryHelper {


        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        public static WindowsIdentity GetWindowsIdentity(string domainName, string userName, string password) {

            WindowsIdentity result = null;
            SafeTokenHandle safeTokenHandle;
            try {
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;

                bool returnValue = LogonUser(userName, domainName, password,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);

                if (false == returnValue) {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle) {
                    result = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                }
            }
            catch {

            }
            return result;
        }


        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid {
            private SafeTokenHandle()
                : base(true) {
            }

            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);

            protected override bool ReleaseHandle() {
                return CloseHandle(handle);
            }
        }
    }


}
