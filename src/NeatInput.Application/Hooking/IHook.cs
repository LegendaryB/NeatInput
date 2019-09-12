using System;

namespace NeatInput.Application.Hooking
{
    public interface IHook : IDisposable
    {
        void Set();
    }
}
