using NeatInput.Application.Hooking;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Hooking.Mouse;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Hooking
{
    internal class MouseHook : InputHook,
        IMouseHook
    {
        protected override int HookID => WH_MOUSE_LL;

        private readonly MouseInputProcessorPipeline _processorPipeline;

        public MouseHook()
        {
            _processorPipeline = new MouseInputProcessorPipeline();
        }

        protected override IntPtr OnInputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (InputReceived == null)
                return base.OnInputReceived(nCode, wParam, lParam);

            if (nCode >= 0 && lParam != IntPtr.Zero)
            {
                var msg = (WindowsMessages)wParam.ToInt32();
                var msllhookstruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

                var input = _processorPipeline.Process(
                    msg,
                    msllhookstruct);

                InputReceived?.Invoke(input);
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }
    }
}
