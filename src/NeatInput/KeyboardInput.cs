using NeatInput.Win32.Enums;

namespace NeatInput
{
    public struct KeyboardInput
    {
        public VirtualKeyCodes Key { get; set; }
        public bool IsPressed { get; set; }
    }
}
