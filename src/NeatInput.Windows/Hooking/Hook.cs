using NeatInput.Windows.Win32;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.SafeHandles;
using NeatInput.Windows.Win32.Structs;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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

        private bool disposing;

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

            return User32.CallNextHookEx(hhk, nCode, wParam, lParam);
        }

        internal void SetHook()
        {
            lpfn = OnReceived;
            var lpfnPtr = Marshal.GetFunctionPointerForDelegate(lpfn);

            hhk = User32.SetWindowsHookEx(Type, lpfnPtr, _hModule, 0);

            MSG msg = new MSG();

            while(User32.GetMessage(ref msg, IntPtr.Zero, 0, 0) && !disposing)
            {
                User32.TranslateMessage(ref msg);
                User32.DispatchMessage(ref msg);
            }
        }

        public void Dispose()
        {
            disposing = true;
            hhk.Dispose();
        }

        ~Hook() => Dispose();
    }
}
