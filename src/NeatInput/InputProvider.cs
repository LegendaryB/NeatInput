using NeatInput.Application.Hooking;
using NeatInput.Domain.Processing;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Hooking;

using System;

namespace NeatInput
{
    public class InputProvider : IDisposable
    {
        public delegate void InputReceivedDelegate(Input input);
        public delegate void MouseInputReceivedDelegate(MouseInput input);

        public event InputReceivedDelegate InputReceived;
        public event InputReceivedDelegate KeyboardInputReceived;
        public event MouseInputReceivedDelegate MouseInputReceived;

        private readonly InputDevice<IKeyboardHook, KeyboardHook> _keyboard;
        private readonly InputDevice<IMouseHook, MouseHook> _mouse;

        public InputProvider()
        {
            _keyboard = new InputDevice<IKeyboardHook, KeyboardHook>();
            _keyboard.InputReceivedHandler = InputEventReceivedHandler;
            _mouse = new InputDevice<IMouseHook, MouseHook>();
            _mouse.InputReceivedHandler = InputEventReceivedHandler;

            AppDomain.CurrentDomain.ProcessExit += OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainLifetimeEnded;
        }

        private void InputEventReceivedHandler(Input input)
        {
            InputReceived?.Invoke(input);

            if (input.GetType() == typeof(MouseInput))
                MouseInputReceived?.Invoke(input as MouseInput);
            else
                KeyboardInputReceived?.Invoke(input);
        }

        private void OnAppDomainLifetimeEnded(object s, dynamic e) => Dispose();

        public void Dispose()
        {
            _keyboard.Dispose();
            _mouse.Dispose();
        }
    }
}
