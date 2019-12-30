using NeatInput.Abstractions;
using NeatInput.Platform.Windows.Hooking;

using System;

namespace NeatInput.Platform.Windows
{
    public class InputSource : IInputSource
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        public InputSource(IntPtr hModule)
        {
            // todo: replace with essentials
            if (hModule == IntPtr.Zero)
                throw new ArgumentException();

            keyboardHook = new KeyboardHook(hModule);
            mouseHook = new MouseHook(hModule);
        }

        public void Dispose()
        {
        }

        ~InputSource() => Dispose();
    }
}
