using NeatInput.Domain.Native.Enums;

using System;

namespace NeatInput.Domain.Native.Structures
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
