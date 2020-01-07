using static Interop.User32;

using System;

namespace NeatInput.Windows.Hooking
{
    internal static class ThreadContext
    {
        private static bool continueLoop;

        internal static void MessageLoop()
        {
            MSG msg = new MSG();

            while (GetMessageW(ref msg, IntPtr.Zero, WM_KEYFIRST, WM_MOUSEFIRST) && !continueLoop)
            {
                TranslateMessage(ref msg);
                DispatchMessageW(ref msg);
            }
        }

        internal static void Stop() => continueLoop = true;
    }
}
