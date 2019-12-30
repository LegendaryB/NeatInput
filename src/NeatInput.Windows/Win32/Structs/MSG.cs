using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        IntPtr hwnd;
        uint message;
        UIntPtr wParam;
        IntPtr lParam;
        int time;
        POINT pt;
    }
}
