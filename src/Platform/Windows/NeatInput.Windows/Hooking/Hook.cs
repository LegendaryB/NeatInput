using NeatInput.Windows.Native;
using NeatInput.Windows.Native.Enumerations;
using NeatInput.Windows.Native.SafeHandles;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
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

            // todo: research about parameters (thread id etc.)
            hhk = User32.SetWindowsHookEx(Type, lpfnPtr, hMod, 0);
        }
    }
}
