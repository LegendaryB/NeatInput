using System;
using System.Runtime.InteropServices;

namespace NeatInput.Win32
{
    internal static class Kernel32
    {
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();
    }
}
