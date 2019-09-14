using NeatInput.Application.Processing.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Domain.Processing.Mouse.Enums;

namespace NeatInput.Processing.Mouse
{
    internal class WheelProcessor :
        IMouseInputProcessor
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages windowsMessage,
            MSLLHOOKSTRUCT hookStruct)
        {
            if (input.Key != MouseKeys.WHEEL)
                return;

            if (ProcessorHelpers.HIWORD(hookStruct.mouseData) > 0)
                input.State = MouseStates.KeyUp;
            else
                input.State = MouseStates.KeyDown;
        }
    }
}
