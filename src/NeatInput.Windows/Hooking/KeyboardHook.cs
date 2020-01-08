using static Interop.User32;
using NeatInput.Windows.Events;
using NeatInput.Windows.Processing;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal class KeyboardHook : Hook
    {
        internal event Action<KeyboardEvent> RawInputProcessed;

        protected override WH Type => WH.KEYBOARD_LL;

        protected override void ProcessRawInput(WindowMessage message, IntPtr lParam)
        {
            var data = RawInputProcessor.Keyboard.Transform(
                message,
                Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam));

            RawInputProcessed?.Invoke(data);
        }
    }
}
