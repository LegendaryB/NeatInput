using System;
using static Interop.User32;

namespace NeatInput.Windows.Hooking
{
    internal static class MessageLoop
    {
        private static bool isDisposing;

        internal static void Run()
        {
            MSG msg = new MSG();

            while (GetMessage(ref msg, IntPtr.Zero, 0, 0) && !isDisposing)
            {
                TranslateMessage(ref msg);
                DispatchMessageW(ref msg);
            }
        }

        internal static void Stop() => isDisposing = true;
    }
}
