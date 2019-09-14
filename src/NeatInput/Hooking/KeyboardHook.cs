using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Keyboard.Enums;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Hooking
{
    internal class KeyboardHook : InputHook
    {
        protected override int HookID => WH_KEYBOARD_LL;

        protected override IntPtr OnInputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (InputReceived == null)
                return base.OnInputReceived(nCode, wParam, lParam);

            if (nCode >= 0)
            {
                var msg = (WindowsMessages)wParam.ToInt32();

                var input = new KeyboardInput((KeyCodes)Marshal.ReadInt32(lParam));

                switch (msg)
                {
                    case WindowsMessages.WM_KEYDOWN:
                    case WindowsMessages.WM_SYSKEYDOWN:
                        input.State = KeyState.Down;
                        break;

                    case WindowsMessages.WM_KEYUP:
                    case WindowsMessages.WM_SYSKEYUP:
                        input.State = KeyState.Up;
                        break;
                }

                InputReceived?.Invoke(input);
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }

    }
}
