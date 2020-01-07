using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal abstract class Hook : IDisposable
    {
        protected abstract HookType Type { get; }

        private delegate IntPtr InputHookProcedure(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        private readonly IntPtr _hModule;
        private InputHookProcedure lpfn;
        private SetWindowsHookExSafeHandle hhk;

        internal Hook()
        {
            _hModule = Process.GetCurrentProcess()
                .MainModule
                .BaseAddress;
        }

        protected abstract void ProcessRawInput(WindowsMessages msg, IntPtr lParam);

        protected IntPtr OnReceived(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0 && wParam != default && lParam != default)
                ProcessRawInput((WindowsMessages)wParam, lParam);

            return Interop.User32.CallNextHookEx(hhk, nCode, wParam, lParam);
        }

        internal void SetHook()
        {
            lpfn = OnReceived;
            var lpfnPtr = Marshal.GetFunctionPointerForDelegate(lpfn);

            hhk = Interop.User32.SetWindowsHookEx(Type, lpfnPtr, _hModule, 0);
        }

        public void Dispose()
        {
            disposing = true;
            hhk.Dispose();
        }

        ~Hook() => Dispose();
    }
}
