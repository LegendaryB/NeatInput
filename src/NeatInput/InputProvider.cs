using NeatInput.Application.Devices;
using NeatInput.Devices;

using System;

namespace NeatInput
{
    public class InputProvider : IDisposable
    {
        public IKeyboard Keyboard { get; }
        public IMouse Mouse { get; }

        // todo generic on input event

        public InputProvider()
        {
            Keyboard = new Keyboard();
            //Mouse = new Mouse();

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
