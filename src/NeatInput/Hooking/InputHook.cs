using NeatInput.Application.Hooking;
using NeatInput.Domain.Hooking;
using NeatInput.Native;
using NeatInput.Native.SafeHandles;

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Interop;

namespace NeatInput.Hooking
{
    internal abstract class InputHook : IHook
    {
        public Action<Input> InputReceived { get; set; }

        protected const int WH_KEYBOARD_LL = 13;
        protected const int WH_MOUSE_LL = 14;

        protected abstract int HookID { get; }

        private SetWindowsHookExSafeHandle setWindowsHookExSafeHandle;
        private readonly IntPtr _mainModuleHandle;
        private readonly CancellationTokenSource _cts;

        public InputHook()
        {
            _cts = new CancellationTokenSource();

            using (var process = Process.GetCurrentProcess())
            {
                process.PriorityClass = ProcessPriorityClass.RealTime;
                _mainModuleHandle = process.MainModule.BaseAddress;
            }
        }

        public virtual void Set()
        {
            var thread = new Thread(() => SetHookAndRunMessageLoop());
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        protected virtual IntPtr OnInputReceived(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            return User32.CallNextHookEx(
                setWindowsHookExSafeHandle.DangerousGetHandle(),
                nCode,
                wParam,
                lParam);
        }

        public virtual void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
            setWindowsHookExSafeHandle.Dispose();
        }

        private void SetHookAndRunMessageLoop()
        {
            setWindowsHookExSafeHandle = User32.SetWindowsHookEx(
                HookID,
                OnInputReceived,
                _mainModuleHandle,
                0);

            var msg = new MSG();

            while (User32.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
            }
        }
    }
}
