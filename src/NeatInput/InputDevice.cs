using NeatInput.Application.Hooking;
using NeatInput.Domain.Processing;
using System;

namespace NeatInput
{
    internal class InputDevice<TInputSourceInterface, TInputHookImplementation> : IDisposable
        where TInputSourceInterface : class, IHook
        where TInputHookImplementation : class, TInputSourceInterface, new()
    {
        private readonly TInputSourceInterface _hook;

        internal Action<Input> InputReceivedHandler { get; set; }

        internal InputDevice()
        {
            _hook = new TInputHookImplementation();
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
