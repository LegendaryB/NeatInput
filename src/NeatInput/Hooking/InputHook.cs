using NeatInput.Application.Hooking;
using NeatInput.Domain.Hooking;
using NeatInput.Native;

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Interop;

namespace NeatInput.Hooking
{
    internal abstract class InputHook : IHook
    {
        public Action<Input> InputReceived { get; set; }
        public bool IsInstalled { get; private set; }

        protected const int WH_KEYBOARD_LL = 13;
        protected const int WH_MOUSE_LL = 14;

        protected abstract int HookID { get; }

        private IntPtr hhk;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();        

        public virtual void Set()
        {
            var callback = new WaitCallback((stateInfo) =>
            {
                SetHookAndRunMessageLoop();
            });

            ThreadPool.QueueUserWorkItem(callback, _cts.Token);
        }

        protected virtual IntPtr OnInputReceived(
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

        public virtual void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();

            IsInstalled = User32.UnhookWindowsHookEx(hhk);
        }

        private void SetHookAndRunMessageLoop()
        {
            using (var process = Process.GetCurrentProcess())
            {
                hhk = User32.SetWindowsHookEx(
                    HookID,
                    OnInputReceived,
                    process.MainModule.BaseAddress,
                    0);
            }

            IsInstalled = hhk != IntPtr.Zero;

            var msg = new MSG();

            while (User32.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
            }
        }
    }
}
