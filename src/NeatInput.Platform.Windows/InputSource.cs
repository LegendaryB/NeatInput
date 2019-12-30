using NeatInput.Abstractions;
using NeatInput.Platform.Windows.Hooking;

using FluentAssertions;

using System;
using System.Threading;

namespace NeatInput.Platform.Windows
{
    public class InputSource : IInputSource
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        public InputSource(
            IntPtr hModule,
            IKeyboardReceiver keyboardReceiver = null,
            IMouseReceiver mouseReceiver = null)
        {
            hModule.Should().NotBeEquivalentTo(IntPtr.Zero);

            if (keyboardReceiver == null && mouseReceiver == null)
                throw new InvalidOperationException();

            if (keyboardReceiver != null)
                keyboardHook = new KeyboardHook(hModule);

            if (mouseReceiver != null)
                mouseHook = new MouseHook(hModule);
        }

        public void Capture()
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
