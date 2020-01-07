using System;
using System.Drawing;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public WindowMessage message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;
        }
    }
}
