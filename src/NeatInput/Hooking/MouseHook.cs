using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NeatInput.Application.Hooking;
using NeatInput.Domain;
using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

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

                var hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

                var input = new Input(DeviceTypes.Mouse);

                switch (msg)
                {
                    case WindowsMessages.WM_LBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;
                    case WindowsMessages.WM_LBUTTONUP:
                        input.State = KeyState.Up;
                        break;
                    case WindowsMessages.WM_RBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;
                    case WindowsMessages.WM_RBUTTONUP:
                        input.State = KeyState.Up;
                        break;
                    //case WindowsMessages.WM_MOUSEMOVE:
                    //    input.State = KeyState.Undefined;
                    //    break;
                    //case WindowsMessages.WM_MOUSEWHEEL:
                    //    MouseWheel?.Invoke(msllHookStruct);
                    //    break;
                    //case WindowsMessages.WM_LBUTTONDBLCLK:
                    //    MouseDoubleClick?.Invoke(msllHookStruct);
                        //break;
                    case WindowsMessages.WM_MBUTTONDOWN:
                        input.State = KeyState.Down;
                        break;
                    case WindowsMessages.WM_MBUTTONUP:
                        input.State = KeyState.Up;
                        break;
                }

                Task.Factory.StartNew(async () => InputReceived?.Invoke(input), TaskCreationOptions.LongRunning);
            }

            return base.OnInputReceived(nCode, wParam, lParam);
        }
    }
}
