using NeatInput.Abstractions;

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
            _instance = GetPlatformImplementation();

            AppDomain.CurrentDomain.ProcessExit += OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainLifetimeEnded;
        }        

        public void Dispose()
        {
            _instance.Dispose();

            AppDomain.CurrentDomain.ProcessExit -= OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException -= OnAppDomainLifetimeEnded;
        }
        private IInputSource GetPlatformImplementation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new WindowsInputSource();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return new LinuxInputSource();
            else
                throw new InvalidOperationException("This library is only available for windows and linux systems!");
        }

        private void OnAppDomainLifetimeEnded(object s, object e) => Dispose();
    }
}
