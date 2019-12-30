using System;

namespace NeatInput.Abstractions
{
    public interface IInputSource : IDisposable
    {
        void Capture();
    }
}
