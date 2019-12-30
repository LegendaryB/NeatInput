using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Platform.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        protected override HookType Type => HookType.WH_MOUSE_LL;

        internal MouseHook(IntPtr hModule) : base(hModule)
        {
        }

        protected override void Process(WindowsMessages msg, IntPtr lParam)
        {
            var data = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
        }
    }
}
