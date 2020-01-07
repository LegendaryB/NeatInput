using NeatInput.Windows.Interop.Handles;

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true, SetLastError = true)]
        internal static extern SetWindowsHookExSafeHandle SetWindowsHookEx(
            WH idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);
    }
}
