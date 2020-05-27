using static Interop.User32;
using static Interop.SafeHandles;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal abstract class Hook : IDisposable
    {
        protected abstract WH Type { get; }

        private delegate IntPtr InputHookProcedure(
            HC nCode,
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

        protected abstract void ProcessRawInput(WindowMessage msg, IntPtr lParam);

        protected IntPtr OnReceived(
            HC nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0 && wParam != default && lParam != default)
            {
                ProcessRawInput((WindowMessage)wParam, lParam);
            }

            return CallNextHookEx(hhk, nCode, wParam, lParam);
        }

        internal void SetHook()
        {
            lpfn = OnReceived;
            var lpfnPtr = Marshal.GetFunctionPointerForDelegate(lpfn);

            hhk = SetWindowsHookExW(Type, lpfnPtr, _hModule, 0);
        }

        public void Dispose()
        {
            hhk?.Dispose();
        }

        ~Hook() => Dispose();
    }
}
