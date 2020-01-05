using System;

namespace NeatInput.Windows
{
    public interface IInputSource : IDisposable
    {
        void Listen();
    }
}
