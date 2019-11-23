using NeatInput.Application;

using WindowsInputSource = NeatInput.Windows.InputSource;
using LinuxInputSource = NeatInput.Linux.InputSource;

using System;
using System.Runtime.InteropServices;


namespace NeatInput
{
    public class InputSource : IInputSource
    {
        private readonly IInputSource _instance;

        public InputSource()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                _instance = new WindowsInputSource();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                _instance = new LinuxInputSource();
            else
                throw new InvalidOperationException();
        }
    }
}
