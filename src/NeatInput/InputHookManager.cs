using NeatInput.Win32;

using System;

namespace NeatInput
{
    public static class InputHookManager
    {
        private static bool IsMessageLoopRunning;

        public static void SetKeyboardHook(out KeyboardHook hook)
        {
            hook = new KeyboardHook();
            ExecuteMessageLoop();
        }

        public static void SetMouseHook(out MouseHook hook)
        {
            hook = new MouseHook();
            ExecuteMessageLoop();
        }

        private static void ExecuteMessageLoop()
        {
            if (!IsMessageLoopRunning)
            {
                if (IsRunningAsConsole())
                    RunPrimitiveWindowsMessageLoop();
            }
        }

        private static bool IsRunningAsConsole()
        {
            return Kernel32.GetConsoleWindow() != IntPtr.Zero;
        }

        private static void RunPrimitiveWindowsMessageLoop()
        {
            IsMessageLoopRunning = true;

            while (true)
            {
                while (User32.GetMessage(out var msg, IntPtr.Zero, 0, 0) != 0)
                {
                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessage(ref msg);
                }
            }
        }
    }
}
