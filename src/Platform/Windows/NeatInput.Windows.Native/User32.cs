using NeatInput.Windows.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native
{
    public static class User32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateWindowExW(
            uint dwExStyle,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpWindowName,
            uint dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetMessage(ref MSG message, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);
    }
}
