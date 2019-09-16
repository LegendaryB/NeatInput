using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Processing;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Hooking
{
    internal class KeyboardHook : InputHook
    {
        protected override int HookID => WH_KEYBOARD_LL;

        private readonly KeyboardInputPipeline _processingPipeline;

        public KeyboardHook()
        {
            _processingPipeline = new KeyboardInputPipeline();
        }

        protected override IntPtr OnInputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (InputReceived == null)
                return base.OnInputReceived(nCode, wParam, lParam);

            if (nCode >= 0 && lParam != IntPtr.Zero && wParam != IntPtr.Zero)
            {
                var msg = (WindowsMessages)wParam.ToInt32();
                var @struct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                var input = _processingPipeline.Process(msg, @struct);

                InputReceived?.Invoke(input);
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }
    }
}
