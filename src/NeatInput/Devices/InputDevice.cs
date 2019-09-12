using NeatInput.Application.Hooking;

using System;

namespace NeatInput.Devices
{
    internal abstract class InputDevice<TInputHookInterface, TInputHookImplementation> : IDisposable
        where TInputHookInterface : class, IHook
        where TInputHookImplementation : class, TInputHookInterface, new()
    {
        protected TInputHookInterface Hook { get; private set; }

        protected InputDevice()
        {
            Hook = new TInputHookImplementation();
            Hook.Set();
        }

        public void Dispose()
        {
            Hook.Dispose();
        }
    }
}
