using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static class User32
    {
        [DllImport(Libraries.User32, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool GetMessage(
            ref MSG message,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax);

        [DllImport(Libraries.User32)]
        internal static extern bool TranslateMessage(
            [In] ref MSG lpMsg);

        [DllImport(Libraries.User32)]
        internal static extern IntPtr DispatchMessage(
            [In] ref MSG lpmsg);

        [DllImport(Libraries.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SetWindowsHookExSafeHandle SetWindowsHookEx(
            HookType idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport(Libraries.User32, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport(Libraries.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            SetWindowsHookExSafeHandle hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}
