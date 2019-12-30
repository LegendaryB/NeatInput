using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.SafeHandles;
using NeatInput.Platform.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Platform.Windows.Win32
{
    public static class User32
    {
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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SetWindowsHookExSafeHandle SetWindowsHookEx(
            HookType idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(
            SetWindowsHookExSafeHandle hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}
