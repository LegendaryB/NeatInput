using NeatInput.Windows.Native.Constants;

using System;

namespace NeatInput.Windows.Native.Window
{
    internal static class User32Wrapper
    {
        internal static IntPtr CreateWindow()
        {
            return User32.CreateWindow(
                WindowConstants.HWND_MESSAGE_CLASS_NAME, "", 0, 0, 0, 0, 0, WindowConstants.HWND_MESSAGE, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
