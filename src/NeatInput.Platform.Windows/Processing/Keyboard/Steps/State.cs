using NeatInput.Platform.Windows.Processing.Keyboard.Enums;
using NeatInput.Platform.Windows.Win32.Enums;

using Paipurain.Application.Handler;

using System;
using System.Linq;
using System.Collections.Generic;

namespace NeatInput.Platform.Windows.Processing.Keyboard.Steps
{
    internal class State : IHandler<ProcessingValueWrapper>
    {
        private readonly Dictionary<KeyStates, List<WindowsMessages>> _stateMessagesMap;

        internal State()
        {
            _stateMessagesMap = new Dictionary<KeyStates, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
        }

        public ProcessingValueWrapper Handle(ProcessingValueWrapper item)
        {
            Console.WriteLine(GetState(item.Message));

            return item;
        }

        private KeyStates GetState(WindowsMessages msg)
        {
            return _stateMessagesMap
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterDownStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
               WindowsMessages.KEYDOWN,
               WindowsMessages.SYSKEYDOWN
            };

            _stateMessagesMap.Add(KeyStates.Down, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
               WindowsMessages.KEYUP,
               WindowsMessages.SYSKEYUP
            };

            _stateMessagesMap.Add(KeyStates.Up, messages);
        }
    }
}
