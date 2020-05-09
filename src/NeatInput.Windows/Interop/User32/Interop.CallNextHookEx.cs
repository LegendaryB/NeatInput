using static Interop.SafeHandles;

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true)]
        internal static extern IntPtr CallNextHookEx(
            SetWindowsHookExSafeHandle hhk,
            HC nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}
