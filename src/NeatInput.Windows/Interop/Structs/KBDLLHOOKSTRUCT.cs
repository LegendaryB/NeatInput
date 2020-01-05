using NeatInput.Windows.Win32.Enums.Flags;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct KBDLLHOOKSTRUCT
    {
        internal uint vkCode;
        internal uint scanCode;
        internal KBDLLHOOKSTRUCTFlags flags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }
}
