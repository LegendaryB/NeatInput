using NeatInput.Windows.Native.Enums;
using NeatInput.Windows.Native.Structures;

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NeatInput.Windows.Native.Window
{
    public class NativeWindow : IDisposable
    {
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        // todo: weak reference
        private readonly Action<IntPtr, uint, IntPtr, IntPtr> _wndProcSubscriber;

        public IntPtr Handle { get; private set; }

        private bool isDisposing;

        public NativeWindow(Action<IntPtr, uint, IntPtr, IntPtr> wndProcSubscriber)
        {
            if (wndProcSubscriber == null)
                throw new ArgumentNullException(nameof(wndProcSubscriber));

            _wndProcSubscriber = wndProcSubscriber;
        }

        public void StartMessageLoop()
        {
            CreateWindow();

            var thread = new Thread(() =>
            {
                var msg = new MSG();

                while (!isDisposing && User32.GetMessage(ref msg, Handle, 0, 0))
                {
                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessage(ref msg);
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public void Dispose()
        {
            isDisposing = true;
        }

        private void CreateWindow()
        {
            Handle = User32Wrapper.CreateWindow(
                Marshal.GetFunctionPointerForDelegate<WndProcDelegate>(WndProc));
        }

        public IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            _wndProcSubscriber?.Invoke(hWnd, msg, wParam, lParam);

            return User32.DefWindowProc(hWnd, (WindowsMessages)msg, wParam, lParam);
        }
    }
}
