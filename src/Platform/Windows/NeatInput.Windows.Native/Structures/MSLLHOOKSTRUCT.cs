using NeatInput.Windows.Native.Enums.Flags;

using System;

namespace NeatInput.Windows.Native.Structures
{
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public MSLLHOOKSTRUCTFlags flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
}
