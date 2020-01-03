using NeatInput.Windows.Hooking;

using System;
using System.Diagnostics;
using System.Threading;

namespace NeatInput.Windows
{
    public class InputSource : IDisposable
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        public InputSource(
            IKeyboardEventReceiver<KeyboardEvent> keyboardReceiver = null,
            IMouseEventReceiver<MouseEvent> mouseReceiver = null)
        {
            if (keyboardReceiver == null && mouseReceiver == null)
                throw new InvalidOperationException();

            var hModule = Process.GetCurrentProcess()
                .MainModule
                .BaseAddress;

            if (keyboardReceiver != null)
                keyboardHook = new KeyboardHook(hModule);

            if (mouseReceiver != null)
                mouseHook = new MouseHook(hModule);
        }

        public void Listen()
        {
            ExecuteInNewThread(keyboardHook);
            ExecuteInNewThread(mouseHook);
        }

        private void ExecuteInNewThread<THook>(THook hook)
            where THook :Hook
        {
            if (hook == null)
                return;

            var thread = new Thread(() => hook.SetHook())
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };

            thread.Start();
        }

        public void Dispose()
        {
            keyboardHook?.Dispose();
            mouseHook?.Dispose();
        }

        ~InputSource() => Dispose();
    }
}
