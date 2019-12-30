using NeatInput.Abstractions;

using WindowsInputSource = NeatInput.Windows.InputSource;

using System;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public class InputSource : IInputSource
    {
        private readonly IInputSource _instance;

        public InputSource()
        {
            _instance = GetPlatformImplementation();
        }

        public void Dispose()
        {
            _instance.Dispose();
        }
        private IInputSource GetPlatformImplementation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new WindowsInputSource();
            else
                throw new InvalidOperationException("This library is only available for windows systems!");
        }
    }
}
