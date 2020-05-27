using System;
using System.Drawing;

[Flags]
internal enum MSLLHOOKSTRUCTFlags : uint
{
    LLMHF_INJECTED = 0x01,
    LLMHF_LOWER_IL_INJECTED = 0x02
}

internal struct MSLLHOOKSTRUCT
{
    internal Point pt;
    internal uint mouseData;
    internal MSLLHOOKSTRUCTFlags flags;
    internal uint time;
    internal IntPtr dwExtraInfo;
}