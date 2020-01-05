using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.SafeHandles;
using NeatInput.Windows.Win32.Structs;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32
{
    internal static class User32
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern bool GetMessage(
            ref MSG message, 
            IntPtr hWnd, 
            uint wMsgFilterMin, 
            uint wMsgFilterMax);

        [DllImport("user32.dll")]
        internal static extern bool TranslateMessage(
            [In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        internal static extern IntPtr DispatchMessage(
            [In] ref MSG lpmsg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SetWindowsHookExSafeHandle SetWindowsHookEx(
            HookType idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            SetWindowsHookExSafeHandle hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}
