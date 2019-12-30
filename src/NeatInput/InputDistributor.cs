using NeatInput.Abstractions;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public class InputDistributor : IInputDistributor
    {
        private readonly IInputSource _source;

        public InputDistributor()
        {
            _source = ResolvePlatformImplementation();
        }

        private IInputSource ResolvePlatformImplementation()
        {
            var hMod = Process.GetCurrentProcess().MainModule.BaseAddress;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new Platform.Windows.InputSource(hMod);
            else
                throw new InvalidOperationException("This library is only available for windows systems!");
        }

        public void Dispose()
        {
        }

        ~InputDistributor() => Dispose();
    }
}
