using NeatInput.Domain.Hooking;

using System;

namespace NeatInput.Application.Hooking
{
    public interface IHook : IDisposable
    {
        Action<Input> InputReceived { get; set; }

        void Set();
    }
}
