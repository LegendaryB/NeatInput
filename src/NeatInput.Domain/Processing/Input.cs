using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing.Keyboard;

namespace NeatInput.Domain.Processing
{
    public class Input
    {
        public VirtualKeyCodes Key { get; set; }
        public KeyState State { get; set; }

        public Input()
        {
        }

        public Input(VirtualKeyCodes key)
        {
            Key = key;
        }
    }
}
