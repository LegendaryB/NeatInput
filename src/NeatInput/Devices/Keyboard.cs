using NeatInput.Application.Hooking;
using NeatInput.Domain.Hooking;
using NeatInput.Hooking;

using System;

namespace NeatInput.Devices
{
    internal class Keyboard : InputDevice<IKeyboardHook, KeyboardHook>
    {
        public Action<Input> Callback;

        public Keyboard()
        {
            Hook.InputReceived = (input) =>
            {
                Callback.Invoke(input);
                // Console.WriteLine($"Key: {input.Key} | State: {input.State}");
            };
        }
    }
}
