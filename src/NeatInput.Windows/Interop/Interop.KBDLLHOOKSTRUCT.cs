using System;
using System.Runtime.InteropServices;

[Flags]
internal enum KBDLLHOOKSTRUCTFlags : uint
{
    LLKHF_EXTENDED = 0x01,
    LLKHF_LOWER_IL_INJECTED = 0x02,
    LLKHF_INJECTED = 0x10,
    LLKHF_ALTDOWN = 0x20,
    LLKHF_UP = 0x80
}

[StructLayout(LayoutKind.Sequential)]
internal struct KBDLLHOOKSTRUCT
{
    internal uint vkCode;
    internal uint scanCode;
    internal KBDLLHOOKSTRUCTFlags flags;
    internal uint time;
    internal UIntPtr dwExtraInfo;
}
