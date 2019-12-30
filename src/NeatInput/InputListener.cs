using NeatInput.Abstractions;

using LegendaryB.Essentials.ArgumentValidation;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NeatInput
{
    public class InputListener : 
        IInputListener,
        IInputReceiver
    {
        private readonly IInputSource _source;

        // todo: weak reference!
        private readonly IKeyboardReceiver _keyboardReceiver;
        private readonly IMouseReceiver _mouseReceiver;

        public InputListener(IInputReceiver receiver)
        {
            Argument.NotNull(
                receiver, 
                nameof(receiver));

            _keyboardReceiver = receiver;
            _mouseReceiver = receiver;
            _source = ResolvePlatformImplementation();
        }

        public InputListener(IKeyboardReceiver keyboardReceiver)
        {
            Argument.NotNull(
                keyboardReceiver,
                nameof(keyboardReceiver));

            _keyboardReceiver = keyboardReceiver;
            _source = ResolvePlatformImplementation();
        }

        public InputListener(IMouseReceiver mouseReceiver)
        {
            Argument.NotNull(
                mouseReceiver,
                nameof(mouseReceiver));

            _mouseReceiver = mouseReceiver;
            _source = ResolvePlatformImplementation();
        }

        public void Listen() => 
            _source.Capture();

        private IInputSource ResolvePlatformImplementation()
        {
            var hModule = Process.GetCurrentProcess()
                .MainModule
                .BaseAddress;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new Platform.Windows.InputSource(hModule, _keyboardReceiver, _mouseReceiver);
            else
                throw new InvalidOperationException("This library is only available for windows systems!");
        }

        public void Dispose() => _source.Dispose();

        ~InputListener() => Dispose();
    }
}
