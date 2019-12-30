using NeatInput.Platform.Windows.Win32;
using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.SafeHandles;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Platform.Windows.Hooking
{
    internal abstract class Hook : IDisposable
    {
        private delegate IntPtr InputHookProcedure(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        private readonly InputHookProcedure lpfn;
        private SetWindowsHookExSafeHandle hhk;

        public Hook()
        {
            lpfn = OnInputCaptured;
            SetHook();
        }

        public void Dispose()
        {
            hhk.Dispose();
        }

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

        private void SetHook()
        {
            var lpfnPtr = Marshal.GetFunctionPointerForDelegate(lpfn);
            var hMod = Process.GetCurrentProcess().MainModule.BaseAddress;

            hhk = User32.SetWindowsHookEx(Type, lpfnPtr, hMod, 0);
        }
    }
}
