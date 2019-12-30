using NeatInput.Abstractions;

using LegendaryB.Essentials.ArgumentValidation;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public class InputDistributor : IInputDistributor,
        IInputReceiver
    {
        private readonly IInputSource _source;

        public InputDistributor(IInputReceiver receiver)
            : this()
        {
            Argument.NotNull(
                receiver, 
                nameof(receiver));
        }

        public InputDistributor(IKeyboardReceiver keyboardReceiver)
            : this()
        {
            Argument.NotNull(
                keyboardReceiver,
                nameof(keyboardReceiver));
        }

        public InputDistributor(IMouseReceiver mouseReceiver)
            : this()
        {
            Argument.NotNull(
                mouseReceiver,
                nameof(mouseReceiver));
        }

        private InputDistributor()
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
