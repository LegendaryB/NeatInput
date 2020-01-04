using NeatInput.Windows.Win32.Enums.Flags;

using System;

namespace NeatInput.Windows.Win32.Structs
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
