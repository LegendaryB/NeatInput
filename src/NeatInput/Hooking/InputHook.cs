using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
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
    internal abstract class InputHook<TInput, TInputStruct, TInputPipeline>
        where TInput : Input
        where TInputStruct : struct
        where TInputPipeline : IInputPipeline<TInput, TInputStruct>, new()
    {
        public Action<TInput> InputReceived { get; set; }

        protected abstract int HookID { get; }

        private HookProc _hookProc;
        private SetWindowsHookExSafeHandle setWindowsHookExSafeHandle;

        private readonly TInputPipeline _pipeline;
        private readonly CancellationTokenSource _cts;
        private readonly IntPtr _mainModuleHandle;        

        public InputHook()
        {
            _pipeline = new TInputPipeline();
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
            if (InputReceived != null)
            {
                if (nCode >= 0 && lParam != IntPtr.Zero && wParam != IntPtr.Zero)
                {
                    var msg = (WindowsMessages)wParam.ToInt32();
                    var @struct = Marshal.PtrToStructure<TInputStruct>(lParam);

                    var input = _pipeline.Process(msg, @struct);

                    InputReceived?.Invoke(input);
                }
            }

            return CallNextHookEx(
                setWindowsHookExSafeHandle,
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
