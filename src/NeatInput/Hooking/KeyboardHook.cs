using NeatInput.Application.Hooking;
using NeatInput.Domain;
using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NeatInput.Hooking
{
    internal class KeyboardHook : InputHook,
        IKeyboardHook
    {
        protected override int HookID => WH_KEYBOARD_LL;

        protected override IntPtr OnInputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (InputReceived == null)
                return base.OnInputReceived(nCode, wParam, lParam);

            if (nCode >= 0)
            {
                var msg = (WindowsMessages)wParam.ToInt32();

                var input = new Input(
                    (VirtualKeyCodes)Marshal.ReadInt32(lParam), 
                    DeviceTypes.Keyboard);

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

                Task.Run(async () => InputReceived?.Invoke(input));
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }

    }
}
