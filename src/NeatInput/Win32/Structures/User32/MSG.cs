using System;

namespace NeatInput.Win32.Structures.User32
{
    internal struct MSG
    {
        public IntPtr hwnd;
        public IntPtr lParam;
        public int message;
        public int pt_x;
        public int pt_y;
        public int time;
        public IntPtr wParam;
    }
}
