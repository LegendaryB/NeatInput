using NeatInput.Application.Hooking;
using NeatInput.Domain;
using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Hooking
{
    internal class MouseHook : InputHook,
        IMouseHook
    {
        protected override int HookID => WH_MOUSE_LL;

        protected override IntPtr OnInputReceived(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (InputReceived == null)
                return base.OnInputReceived(nCode, wParam, lParam);

            if (nCode >= 0)
            {
                var msg = (WindowsMessages)wParam.ToInt32();

                var @struct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

                var input = new Input(DeviceTypes.Mouse);

                switch (msg)
                {
                    #region LEFT MOUSE BUTTON

                    case WindowsMessages.WM_LBUTTONDOWN:
                    case WindowsMessages.WM_NCLBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;

                    case WindowsMessages.WM_LBUTTONUP:
                    case WindowsMessages.WM_NCLBUTTONUP:
                        input.State = KeyState.Up;
                        break;

                    case WindowsMessages.WM_LBUTTONDBLCLK:
                    case WindowsMessages.WM_NCLBUTTONDBLCLK:
                        input.State = KeyState.Pressed;
                        break;

                    #endregion

                    #region RIGHT MOUSE BUTTON

                    case WindowsMessages.WM_RBUTTONDOWN:
                    case WindowsMessages.WM_NCRBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;

                    case WindowsMessages.WM_RBUTTONUP:
                    case WindowsMessages.WM_NCRBUTTONUP:
                        input.State = KeyState.Up;
                        break;

                    case WindowsMessages.WM_RBUTTONDBLCLK:
                    case WindowsMessages.WM_NCRBUTTONDBLCLK:
                        input.State = KeyState.Pressed;
                        break;

                    #endregion

                    #region MIDDLE MOUSE BUTTON

                    case WindowsMessages.WM_MBUTTONDOWN:
                    case WindowsMessages.WM_NCMBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;

                    case WindowsMessages.WM_MBUTTONUP:
                    case WindowsMessages.WM_NCMBUTTONUP:
                        input.State = KeyState.Up;
                        break;

                    case WindowsMessages.WM_MBUTTONDBLCLK:
                    case WindowsMessages.WM_NCMBUTTONDBLCLK:
                        input.State = KeyState.Pressed;
                        break;

                    #endregion
                }

                input.X = @struct.pt.X;
                input.Y = @struct.pt.Y;

                InputReceived?.Invoke(input);
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }
    }
}
