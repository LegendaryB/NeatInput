using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Structures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WNDCLASSEX
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public int style;
        public IntPtr lpfnWndProc; // not WndProc
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;

        public static WNDCLASSEX Build()
        {
            return new WNDCLASSEX
            {
                cbSize = Marshal.SizeOf(typeof(WNDCLASSEX))
            };
        }
    }
}
