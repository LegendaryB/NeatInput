using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Domain.Hooking
{
    public class Input
    {
        public VirtualKeyCodes Key { get; }
        public KeyState State { get; set; }
        public DeviceTypes DeviceType { get; }
        public int X { get; set; }
        public int Y { get; set;  }

        public Input(IntPtr key, DeviceTypes deviceType)
        {
            Key = (VirtualKeyCodes)Marshal.ReadInt32(key);
            DeviceType = deviceType;
        }
    }
}
