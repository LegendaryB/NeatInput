using NeatInput.Windows.Events;
using NeatInput.Windows.Processing;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal class KeyboardHook : Hook
    {
        internal event Action<KeyboardEvent> RawInputProcessed;

        protected override HookType Type => HookType.WH_KEYBOARD_LL;

        protected override void ProcessRawInput(WindowsMessages message, IntPtr lParam)
        {
            var data = RawInputProcessor.Keyboard.Transform(
                message,
                Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam));

            RawInputProcessed?.Invoke(data);
        }
    }
}
