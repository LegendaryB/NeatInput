using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true)]
        internal static extern bool PeekMessageW(
            ref MSG msg,
            IntPtr hwnd = default,
            WindowMessage msgMin = 0,
            WindowMessage msgMax = 0,
            PM remove = PM.NOREMOVE);
    }
}
