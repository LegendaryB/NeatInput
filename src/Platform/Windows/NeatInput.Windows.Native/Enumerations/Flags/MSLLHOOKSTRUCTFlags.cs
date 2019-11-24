using System;

namespace NeatInput.Windows.Native.Enumerations.Flags
{
    [Flags]
    public enum MSLLHOOKSTRUCTFlags : uint
    {
        LLMHF_INJECTED = 0x01,
        LLMHF_LOWER_IL_INJECTED = 0x02
    }
}
