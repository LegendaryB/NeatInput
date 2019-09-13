using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Hooking.Mouse.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

namespace NeatInput.Hooking.Mouse.Processing
{
    internal class WheelProcessor :
        IMouseInputProcessor
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages windowsMessage,
            MSLLHOOKSTRUCT hookStruct)
        {
            if (input.Key != VirtualKeyCodes.SCROLL)
                return;

            if (ProcessorHelpers.HIWORD(hookStruct.mouseData) > 0)
                input.State = KeyState.Up;
            else
                input.State = KeyState.Down;
        }
    }
}
