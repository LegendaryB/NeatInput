using NeatInput.Domain.Native.Enums;
using System;
using System.Runtime.InteropServices;

namespace NeatInput.Domain.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class KBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public KBDLLHOOKSTRUCTFlags flags;
        public uint time;
        public UIntPtr dwExtraInfo;
    }
}
