using NeatInput.Application.Devices;
using NeatInput.Application.Hooking;
using NeatInput.Hooking;

namespace NeatInput.Devices
{
    internal class Keyboard : InputDevice<IKeyboardHook, KeyboardHook>,
        IKeyboard
    {
    }
}
