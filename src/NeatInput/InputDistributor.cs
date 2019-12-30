using NeatInput.Abstractions;

using System;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public class InputDistributor : IInputDistributor
    {
        private readonly IInputSource Source;

        public InputDistributor()
        {
            Source = ResolvePlatformImplementation();
        }

        private IInputSource ResolvePlatformImplementation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new Platform.Windows.InputSource();
            else
                throw new InvalidOperationException("This library is only available for windows systems!");
        }

        public void Dispose()
        {
        }

        ~InputDistributor() => Dispose();
    }
}
