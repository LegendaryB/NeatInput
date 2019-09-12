using System;
using NeatInput.Application.Hooking;
using NeatInput.Domain.Native.Enums;

namespace NeatInput.Hooking
{
    internal class KeyboardHook : InputHook,
        IKeyboardHook
    {
        protected override int HookID => WH_KEYBOARD_LL;

        protected override IntPtr InputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var msg = (WindowsMessages)wParam.ToInt32();

                //if (Inp)
            }

            return base.InputReceived(nCode, wParam, lParam);
        }

    }
}
