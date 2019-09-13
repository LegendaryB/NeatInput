using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

using System;

namespace NeatInput.Hooking.Mouse
{
    internal class XButtonProcessor :
        IMouseInputProcessor
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages windowsMessage, 
            MSLLHOOKSTRUCT hookStruct)
        {
            if (input.Key != VirtualKeyCodes.XBUTTON1)
                return;

            Console.WriteLine(HIWORD(hookStruct.mouseData));

            if (HIWORD(hookStruct.mouseData) == 0x2)
                input.Key = VirtualKeyCodes.XBUTTON2;
        }

        private ushort HIWORD(uint value)
        {
            return (ushort)((value >> 16) & 0xFFFF);
        }
    }
}
