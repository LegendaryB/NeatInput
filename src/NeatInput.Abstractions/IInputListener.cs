using System;

namespace NeatInput.Abstractions
{
    public interface IInputListener : IDisposable
    {
        void Listen();
    }
}
