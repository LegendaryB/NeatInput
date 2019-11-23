using NeatInput.Windows.Native.Enums;
using NeatInput.Windows.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native
{
    public static class User32
    {
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowExW")]
        public static extern IntPtr CreateWindowExW(
            uint dwExStyle,
            string lpClassName,
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

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassExW")]
        public static extern ushort RegisterClassExW(
            ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", EntryPoint = "UnregisterClassW")]
        public static extern bool UnregisterClassW(
            string lpClassName,
            IntPtr hInstance);

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(
            IntPtr hWnd,
            WindowsMessages uMsg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetMessage(
            ref MSG message, 
            IntPtr hWnd, 
            uint wMsgFilterMin, 
            uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage(
            [In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage(
            [In] ref MSG lpmsg);
    }
}
