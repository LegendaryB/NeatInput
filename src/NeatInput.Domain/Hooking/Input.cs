using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;

namespace NeatInput.Domain.Hooking
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
