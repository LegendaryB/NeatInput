using NeatInput.Windows.Win32.Enums.Flags;

using System;

namespace NeatInput.Windows.Win32.Structs
{
    internal struct MSLLHOOKSTRUCT
    {
        internal POINT pt;
        internal uint mouseData;
        internal MSLLHOOKSTRUCTFlags flags;
        internal uint time;
        internal IntPtr dwExtraInfo;
    }
}
