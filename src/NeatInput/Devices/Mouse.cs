using NeatInput.Application.Devices;
using NeatInput.Application.Hooking;
using NeatInput.Hooking;

namespace NeatInput.Devices
{
    internal class Mouse : InputDevice<IMouseHook, MouseHook>,
        IMouse
    {
    }
}
