using static Interop.User32;
using NeatInput.Windows.Events;
using NeatInput.Windows.Processing;

using System;
using System.Runtime.InteropServices;


namespace NeatInput.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        internal event Action<MouseEvent> RawInputProcessed;

        protected override WH Type => WH.MOUSE_LL;

        protected override void ProcessRawInput(WindowMessage message, IntPtr lParam)
        {
            var data = RawInputProcessor.Mouse.Transform(
                message,
                Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam));

            RawInputProcessed?.Invoke(data);
        }
    }
}
