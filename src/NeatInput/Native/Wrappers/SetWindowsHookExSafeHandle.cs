using System;
using System.Runtime.ConstrainedExecution;

using Microsoft.Win32.SafeHandles;

namespace NeatInput.Native.Wrappers
{
    public class SetWindowsHookExSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SetWindowsHookExSafeHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            return User32.UnhookWindowsHookEx(handle);
        }
    }
}
