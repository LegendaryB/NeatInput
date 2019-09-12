using NeatInput.Application.Devices;
using NeatInput.Application.Hooking;
using NeatInput.Hooking;

using System;

namespace NeatInput.Devices
{
    internal class Keyboard : InputDevice<IKeyboardHook, KeyboardHook>,
        IKeyboard
    {
        public Keyboard()
        {
            Hook.InputReceived = (input) =>
            {
                Console.WriteLine($"Key: {input.Key} | State: {input.State}");
            };
        }
    }
}
