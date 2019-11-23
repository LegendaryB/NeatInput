using NeatInput.Windows.Native.Constants;
using NeatInput.Windows.Native.Structures;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Window
{
    internal static class User32Wrapper
    {
        private static readonly uint WNDCLASSEX_SIZE = (uint)Marshal.SizeOf<WNDCLASSEX>();

        internal static IntPtr CreateWindow(IntPtr lpfnWndProc)
        {
            var wx = new WNDCLASSEX
            {
                cbSize = WNDCLASSEX_SIZE,
                lpfnWndProc = lpfnWndProc,
                lpszClassName = Guid.NewGuid().ToString().Replace("-", string.Empty),
                hInstance = Process.GetCurrentProcess().Handle
            };

            if (User32.RegisterClassExW(ref wx) == 0)
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());

            var handle = User32.CreateWindowExW(0,
                wx.lpszClassName,
                string.Empty, 0, 0, 0, 0, 0,
                WindowConstants.HWND_MESSAGE,
                IntPtr.Zero,
                wx.hInstance,
                IntPtr.Zero);

            if (handle == IntPtr.Zero)
                throw new InvalidOperationException("Failed to create native window!");

            return handle;
        }
    }
}
