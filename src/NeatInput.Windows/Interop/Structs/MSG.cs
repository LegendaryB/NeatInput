using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MSG
    {
        internal IntPtr hwnd;
        internal uint message;
        internal UIntPtr wParam;
        internal IntPtr lParam;
        internal int time;
        internal POINT pt;
    }
}
