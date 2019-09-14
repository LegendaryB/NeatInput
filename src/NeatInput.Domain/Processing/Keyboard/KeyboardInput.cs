using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing.Keyboard.Enums;

namespace NeatInput.Domain.Processing.Keyboard
{
    public class KeyboardInput :
        Input
    {
        public KeyCodes Key { get; set; }
        public KeyState State { get; set; }

        public KeyboardInput(KeyCodes key)
        {
            Key = key;
        }
    }
}
