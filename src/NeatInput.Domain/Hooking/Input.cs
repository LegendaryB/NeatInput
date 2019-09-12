using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;

namespace NeatInput.Domain.Hooking
{
    public class Input
    {
        public VirtualKeyCodes Key { get; set; }
        public KeyState State { get; set; }
        public DeviceTypes DeviceType { get; }
        public int X { get; set; }
        public int Y { get; set;  }

        public Input(DeviceTypes deviceType)
        {
            DeviceType = deviceType;
        }

        public Input(VirtualKeyCodes key, DeviceTypes deviceType)
            : this(deviceType)
        {
            Key = key;
        }
    }
}
