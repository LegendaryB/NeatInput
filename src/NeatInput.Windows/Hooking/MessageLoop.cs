using System;

namespace NeatInput.Windows.Hooking
{
    internal static class MessageLoop
    {
        private static bool isDisposing;

        internal static void Run()
        {
            MSG msg = new MSG();

            while (Interop.User32.GetMessage(ref msg, IntPtr.Zero, 0, 0) && !isDisposing)
            {
                Interop.User32.TranslateMessage(ref msg);
                Interop.User32.DispatchMessage(ref msg);
            }
        }

        internal static void Stop() => isDisposing = true;
    }
}
