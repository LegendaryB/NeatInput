using Microsoft.Win32.SafeHandles;

using System.Security.Permissions;

namespace NeatInput.Platform.Windows.Win32.SafeHandles
{
    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    public class SetWindowsHookExSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SetWindowsHookExSafeHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return User32.UnhookWindowsHookEx(handle);
        }
    }
}
