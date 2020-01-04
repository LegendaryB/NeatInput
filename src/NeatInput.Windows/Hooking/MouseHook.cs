using NeatInput.Windows.Events;
using NeatInput.Windows.Processing;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        internal event Action<MouseEvent> RawInputProcessed;

        private readonly MouseProcessor _processor;

        protected override HookType Type => HookType.WH_MOUSE_LL;

        protected override void ProcessRawInput(WindowsMessages msg, IntPtr lParam)
        { 
            var data = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
        }
    }
}
