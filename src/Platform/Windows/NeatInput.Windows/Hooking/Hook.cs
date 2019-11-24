using NeatInput.Windows.Native;
using NeatInput.Windows.Native.Enumerations;
using NeatInput.Windows.Native.SafeHandles;

using System;

namespace NeatInput.Windows.Hooking
{
    internal abstract class Hook
    {
        private delegate IntPtr InputHookProcedure(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        private InputHookProcedure inputHookProcedure;
        private SetWindowsHookExSafeHandle hhk;

        protected abstract HookType Type { get; }

        protected abstract void ProcessInput(WindowsMessages msg, IntPtr lParam);

        protected IntPtr OnInputCaptured(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0 && wParam != default && lParam != default)
                ProcessInput((WindowsMessages)wParam, lParam);

            return User32.CallNextHookEx(hhk, nCode, wParam, lParam);
        }
    }
}
