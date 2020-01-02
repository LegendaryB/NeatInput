using NeatInput.Abstractions;

using FluentValidation;

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
            //RuleFor

            receiver.Should().NotBeNull();

            _keyboardReceiver = receiver;
            _mouseReceiver = receiver;
            _source = ResolvePlatformImplementation();
        }

        public InputListener(IKeyboardReceiver keyboardReceiver)
        {
            keyboardReceiver.Should().NotBeNull();

            _keyboardReceiver = keyboardReceiver;
            _source = ResolvePlatformImplementation();
        }

        public InputListener(IMouseReceiver mouseReceiver)
        {
            mouseReceiver.Should().NotBeNull();

            _mouseReceiver = mouseReceiver;
            _source = ResolvePlatformImplementation();
        }

        public void Listen() => _source.Capture();

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
