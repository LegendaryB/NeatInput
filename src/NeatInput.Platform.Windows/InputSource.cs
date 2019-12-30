using NeatInput.Abstractions;
using NeatInput.Platform.Windows.Hooking;

using System;

namespace NeatInput.Platform.Windows
{
    public class InputSource : IInputSource
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        public InputSource(IntPtr hMod)
        {
            // todo: replace with essentials
            if (hMod == IntPtr.Zero)
                throw new ArgumentException();

            keyboardHook = new KeyboardHook(hMod);
            mouseHook = new MouseHook(hMod);
        }

        public void Dispose()
        {
        }

        ~InputSource() => Dispose();
    }
}
