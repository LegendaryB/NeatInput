using NeatInput.Application.Processing.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;

namespace NeatInput.Processing.Mouse
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

            if (ProcessorHelpers.HIWORD(hookStruct.mouseData) == 0x2)
                input.Key = VirtualKeyCodes.XBUTTON2;
        }
    }
}
