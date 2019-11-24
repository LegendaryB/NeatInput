using NeatInput.Windows.Native.Enumerations;
using NeatInput.Windows.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        protected override HookType Type => HookType.WH_MOUSE_LL;

        protected override void ProcessInput(WindowsMessages msg, IntPtr lParam)
        {
            var data = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
        }
    }
}
