using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Keyboard.Enums;

namespace NeatInput.Processing.Keyboard
{
    internal class KeyProcessor : IInputProcessor<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        public void Process(
            ref KeyboardInput input, 
            WindowsMessages msg, 
            KBDLLHOOKSTRUCT @struct)
        {
            input.Key = (KeyCodes)@struct.vkCode;
        }
    }
}
