using NeatInput.Application.Hooking;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing;
using NeatInput.Native.SafeHandles;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using static NeatInput.Native.User32;

namespace NeatInput.Hooking
{
    internal abstract class InputHook : IHook
    {
        public Action<Input> InputReceived { get; set; }

        protected const int WH_KEYBOARD_LL = 13;
        protected const int WH_MOUSE_LL = 14;

        protected abstract int HookID { get; }

        private HookProc _hookProc;
        private SetWindowsHookExSafeHandle setWindowsHookExSafeHandle;

        private readonly object _lock;
        private readonly CancellationTokenSource _cts;
        private readonly IntPtr _mainModuleHandle;        

        public InputHook()
        {
            _lock = new object();
            _cts = new CancellationTokenSource();

            using (var process = Process.GetCurrentProcess())
            {
                process.PriorityClass = ProcessPriorityClass.RealTime;
                _mainModuleHandle = process.MainModule.BaseAddress;
            }
        }

        public virtual void Set()
        {
            lock (_lock)
            {
                var thread = new Thread(() => SetHookAndRunMessageLoop());
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.Highest;
                thread.Start();
            }
        }

        protected virtual IntPtr OnInputReceived(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            return CallNextHookEx(
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
            _hookProc = OnInputReceived;

            setWindowsHookExSafeHandle = SetWindowsHookEx(
                HookID,
                Marshal.GetFunctionPointerForDelegate(_hookProc),
                _mainModuleHandle,
                0);

            var msg = new MSG();

            while (GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
            }
        }
    }
}
