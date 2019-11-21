using NeatInput.Windows.Native.Flags;
using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Window
{
    public class NativeWindow : IDisposable
    {
        private IntPtr handle;

        delegate IntPtr WndProcDelegate();

        public void Create(Action wndProc)
        {
            handle = User32Wrapper.CreateWindow();

            if (handle == IntPtr.Zero)
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());

            var pWndProc = Marshal.GetFunctionPointerForDelegate<WndProcDelegate>(WndProc);

            var result = User32.SetWindowLongPtr(handle, WindowLongFlags.GWL_WNDPROC, pWndProc);

            if (result == IntPtr.Zero)
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
        }

        private IntPtr WndProc()
        {

            return default;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
