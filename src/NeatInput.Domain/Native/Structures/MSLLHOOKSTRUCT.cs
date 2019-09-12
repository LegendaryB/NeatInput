using System;

namespace NeatInput.Domain.Native.Structures
{
    public struct MSLLHOOKSTRUCT
    {
        public int pt_x;
        public int pt_y;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
}
