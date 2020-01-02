using NeatInput.Platform.Windows.Processing;
using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NeatInput.Platform.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        private readonly MouseProcessor _processor;

        protected override HookType Type => HookType.WH_MOUSE_LL;

        internal MouseHook(IntPtr hModule) 
            : base(hModule)
        {
        }

        protected override Task Process(WindowsMessages msg, IntPtr lParam)
        { 
            var data = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

            return Task.CompletedTask;
        }
    }
}
