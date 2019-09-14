using NeatInput.Application.Hooking;
using NeatInput.Domain.Processing;

using System;

namespace NeatInput
{
    internal class InputDevice<TInputHook> : IDisposable
        where TInputHook : class, IHook, new()
    {
        private readonly TInputHook _hook;

        internal Action<Input> InputReceivedHandler { get; set; }

        internal InputDevice()
        {
            _hook = new TInputHook();
            _hook.Set();

            _hook.InputReceived = ForwardInput;
        }

        private void ForwardInput(Input input) => InputReceivedHandler?.Invoke(input);

        public void Dispose()
        {
            _hook.Dispose();
        }
    }
}
