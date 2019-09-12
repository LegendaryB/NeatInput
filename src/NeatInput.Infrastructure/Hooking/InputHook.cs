using NeatInput.Application.Hooking;
using NeatInput.Infrastructure.Native;

using System;
using System.Diagnostics;

namespace NeatInput.Infrastructure.Hooking
{
    public abstract class InputHook : IHook
    {
        protected const int WH_KEYBOARD_LL = 13;
        protected const int WH_MOUSE_LL = 14;

        public bool IsInstalled { get; private set; }

        protected abstract int HookID { get; }

        private IntPtr hhk;

        public virtual bool Set()
        {
            using (var process = Process.GetCurrentProcess())
            {
                hhk = User32.SetWindowsHookEx(
                    HookID,
                    InputReceived,
                    process.MainModule.BaseAddress,
                    0);

                IsInstalled = hhk != IntPtr.Zero;
                return IsInstalled;
            }
        }

        public virtual bool Unset()
        {
            IsInstalled = User32.UnhookWindowsHookEx(hhk);
            return IsInstalled;
        }

        public virtual void Dispose()
        {
            Unset();
        }

        protected virtual IntPtr InputReceived(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            return User32.CallNextHookEx(
                hhk,
                nCode,
                wParam,
                lParam);
        }
    }
}
