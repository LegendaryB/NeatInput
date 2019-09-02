using NeatInput.Win32;

using System;
using System.Threading.Tasks;

namespace NeatInput
{
    public static class InputHookManager
    {
        private static bool isMessageLoopRunning;

        public static KeyboardHook SetKeyboardHook() =>
            SetHook(new KeyboardHook());

        public static void SetMouseHook() =>
            SetHook(new MouseHook());

        private static THook SetHook<THook>(THook hook)
            where THook : InputHookBase
        {
            Task.Run(() =>
            {
                hook.SetHook();
                ExecuteMessageLoop();
            }).ConfigureAwait(false);

            return hook;
        }

        private static void ExecuteMessageLoop()
        {
            if (!isMessageLoopRunning)
            {
                if (IsRunningAsConsole())
                    RunPrimitiveWindowsMessageLoop();
            }
        }

        private static bool IsRunningAsConsole() =>
            Kernel32.GetConsoleWindow() != IntPtr.Zero;

        private static void RunPrimitiveWindowsMessageLoop()
        {
            isMessageLoopRunning = true;

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
