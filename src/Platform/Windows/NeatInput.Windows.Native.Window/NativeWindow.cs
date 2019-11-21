using NeatInput.Windows.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Window
{
    public class NativeWindow : IDisposable
    {
        public IntPtr Handle { get; private set; }

        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public NativeWindow(Action messageReceivedHandler)
        {

        }

        public void StartMessageLoop()
        {
            CreateWindow();

            var msg = new MSG();

            while (User32.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
                User32.TranslateMessage(ref msg);
                User32.DispatchMessage(ref msg);
            }
        }

        public void Dispose()
        {
            // stop loop etc.
        }

        private void CreateWindow()
        {
            var wndProcPtr = Marshal.GetFunctionPointerForDelegate<WndProcDelegate>(WndProc);
            Handle = User32Wrapper.CreateWindow(wndProcPtr);
        }

        public IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {

            return default;
        }
    }
}
