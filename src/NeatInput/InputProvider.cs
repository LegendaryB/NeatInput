using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Hooking;
using NeatInput.Processing;
using System;

namespace NeatInput
{
    public class InputProvider : IDisposable
    {
        public delegate void InputReceivedDelegate(Input input);
        public delegate void KeyboardInputReceivedDelegate(KeyboardInput input);
        public delegate void MouseInputReceivedDelegate(MouseInput input);

        public event InputReceivedDelegate InputReceived;
        public event KeyboardInputReceivedDelegate KeyboardInputReceived;
        public event MouseInputReceivedDelegate MouseInputReceived;

        private readonly Keyboard _keyboard;
        private readonly Mouse _mouse;

        public InputProvider()
        {
            _keyboard = new Keyboard();
            _keyboard.InputReceived = InputEventReceivedHandler;
            _mouse = new Mouse();
            _mouse.InputReceived = InputEventReceivedHandler;

            _keyboard.Set();
            _mouse.Set();

            AppDomain.CurrentDomain.ProcessExit += OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainLifetimeEnded;
        }

        private void InputEventReceivedHandler(Input input)
        {
            InputReceived?.Invoke(input);

            if (input.GetType() == typeof(MouseInput))
                MouseInputReceived?.Invoke(input as MouseInput);
            else
                KeyboardInputReceived?.Invoke(input as KeyboardInput);
        }

        private void OnAppDomainLifetimeEnded(object s, dynamic e) => Dispose();

        public void Dispose()
        {
            _keyboard.Dispose();
            _mouse.Dispose();
        }
    }
}
