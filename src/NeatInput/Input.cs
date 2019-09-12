using NeatInput.Application.Devices;
using NeatInput.Devices;

using System;

namespace NeatInput
{
    public class Input : IDisposable
    {
        public IKeyboard Keyboard { get; }
        public IMouse Mouse { get; }

        // todo generic on input event

        public Input()
        {
            Keyboard = new Keyboard();
            Mouse = new Mouse();

            Keyboard.

            AppDomain.CurrentDomain.ProcessExit += OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainLifetimeEnded;
        }

        private void OnAppDomainLifetimeEnded(object s, dynamic e) => Dispose();

        public void Dispose()
        {
            Keyboard.Dispose();
            Mouse.Dispose();
        }
    }
}
