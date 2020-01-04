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

        private readonly KeyboardProcessor _processor = new KeyboardProcessor();

        protected override HookType Type => HookType.WH_KEYBOARD_LL;

        protected override void ProcessRawInput(WindowsMessages msg, IntPtr lParam)
        {
            var data = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            RawInputProcessed?.Invoke(_processor.Transform(msg, data));
        }
    }
}
