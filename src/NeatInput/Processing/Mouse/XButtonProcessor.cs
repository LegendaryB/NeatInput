using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Domain.Processing.Mouse.Enums;

namespace NeatInput.Processing.Mouse
{
    internal class XButtonProcessor : IInputProcessor<MouseInput, MSLLHOOKSTRUCT>
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages windowsMessage, 
            MSLLHOOKSTRUCT hookStruct)
        {
            if (input.Key != MouseKeys.XBUTTON1)
                return;

            if (ProcessorHelpers.HIWORD(hookStruct.mouseData) == 0x2)
                input.Key = MouseKeys.XBUTTON2;
        }
    }
}
