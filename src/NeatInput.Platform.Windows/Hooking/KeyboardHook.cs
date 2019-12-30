using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Platform.Windows.Hooking
{
    internal class KeyboardHook : Hook
    {
        protected override HookType Type => HookType.WH_KEYBOARD_LL;

        internal KeyboardHook(IntPtr hMod) : base(hMod)
        {
        }

        protected override void Process(WindowsMessages msg, IntPtr lParam)
        {
            var data = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
        }
    }
}
