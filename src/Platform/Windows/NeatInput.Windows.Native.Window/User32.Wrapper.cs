using NeatInput.Windows.Native.Constants;
using NeatInput.Windows.Native.Structures;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Window
{
    internal static class User32Wrapper
    {
        internal static IntPtr CreateWindow(IntPtr lpfnWndProc)
        {
            var wx = WNDCLASSEX.Build();
            wx.lpfnWndProc = lpfnWndProc;
            wx.lpszClassName = "Message";
            wx.hInstance = Process.GetCurrentProcess().Handle;

            if(User32.RegisterClassEx(ref wx) == 0)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());                
            }

            var handle = User32.CreateWindowExW(
                0, wx.lpszClassName, string.Empty, 0, 0, 0, 0, 0, WindowConstants.HWND_MESSAGE, IntPtr.Zero, wx.hInstance, IntPtr.Zero);

            return handle;
        }
    }
}
