using NeatInput.Platform.Windows.Processing;
using NeatInput.Platform.Windows.Processing.Keyboard;
using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NeatInput.Platform.Windows.Hooking
{
    internal class KeyboardHook : Hook
    {
        private readonly KeyboardProcessor _processor = new KeyboardProcessor();

        protected override HookType Type => HookType.WH_KEYBOARD_LL;

        internal KeyboardHook(IntPtr hModule) 
            : base(hModule)
        {
        }

        protected override async Task Process(WindowsMessages msg, IntPtr lParam)
        {            
            var data = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            await _processor.ExecuteAsync(new ProcessingValueWrapper()
            {
                Message = msg,
                InputStruct = data
            });
        }
    }
}
