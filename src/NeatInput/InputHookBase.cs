using NeatInput.Win32;

using System;
using System.Diagnostics;

namespace NeatInput
{
    public abstract class InputHookBase : IDisposable
    {
        protected abstract int HookID { get; }

        protected IntPtr HookHandle { get; private set; }

        protected InputHookBase() { }

        protected void SetHook()
        {
            using (var process = Process.GetCurrentProcess())
            {
                HookHandle = User32.SetWindowsHookEx(
                    HookID,
                    InputHook,
                    process.MainModule.BaseAddress,
                    0);

                if (HookHandle == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
        }

        protected virtual IntPtr InputHook(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (HookHandle == IntPtr.Zero)
                throw new InvalidOperationException();

            return User32.CallNextHookEx(
                HookHandle,
                nCode,
                wParam,
                lParam);
        }

        public void Dispose()
        {
            User32.UnhookWindowsHookEx(HookHandle);
        }
    }
}
