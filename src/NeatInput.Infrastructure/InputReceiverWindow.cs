using System;
using System.Windows.Forms;

namespace NeatInput.Infrastructure
{
    internal class InputReceiverWindow : NativeWindow
    {
        private readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

        public InputReceiverWindow()
        {
            CreateHandle(new CreateParams() { Parent = HWND_MESSAGE });
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
