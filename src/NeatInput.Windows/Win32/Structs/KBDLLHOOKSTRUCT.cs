using NeatInput.Windows.Win32.Enums.Flags;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public KBDLLHOOKSTRUCTFlags flags;
        public uint time;
        public UIntPtr dwExtraInfo;
    }
}
