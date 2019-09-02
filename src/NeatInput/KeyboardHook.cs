using NeatInput.Win32.Enums;
using NeatInput.Win32.Enums.User32;

using System;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public sealed class KeyboardHook : InputHookBase
    {
        protected override int HookID => 13; // WH_KEYBOARD_LL

        public delegate void KeyboardInputCallback(KeyboardInput input);

        public event KeyboardInputCallback InputReceived;

        internal KeyboardHook() { }

        protected override IntPtr InputHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var messageType = (WindowsMessages)wParam.ToInt32();

                if (InputReceived != null)
                {
                    if (messageType == WindowsMessages.WM_KEYDOWN || messageType == WindowsMessages.WM_SYSKEYDOWN)
                        InputReceived?.Invoke(new KeyboardInput { Key = (VirtualKeyCodes)Marshal.ReadInt32(lParam), IsPressed = true });
                    else if (messageType == WindowsMessages.WM_KEYUP || messageType == WindowsMessages.WM_SYSKEYUP)
                        InputReceived?.Invoke(new KeyboardInput { Key = (VirtualKeyCodes)Marshal.ReadInt32(lParam), IsPressed = false });
                }
            }

            return base.InputHook(nCode, wParam, lParam);
        }
    }
}
