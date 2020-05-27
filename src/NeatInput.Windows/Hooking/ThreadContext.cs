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
            continueLoop = true;

            while (continueLoop)
            {
                if (PeekMessageW(ref msg))
                {
                    if (!GetMessageW(ref msg))
                    {
                        continue;
                    }

                    TranslateMessage(ref msg);
                    DispatchMessageW(ref msg);
                }
                else
                {
                    WaitMessage();
                }
            }
        }

        internal static void Stop() => continueLoop = true;
    }
}
