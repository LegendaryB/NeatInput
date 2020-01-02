using NeatInput.Windows.Processing;
using NeatInput.Windows.Processing.Keyboard;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NeatInput.Windows.Hooking
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

            await _processor.ExecuteAsync(new ValueWrapper()
            {
                Message = msg,
                InputStruct = data,
                Output = new KeyboardEvent()
            });
        }
    }
}
