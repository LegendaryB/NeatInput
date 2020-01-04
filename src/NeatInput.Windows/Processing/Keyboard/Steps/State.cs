using NeatInput.Windows.Processing.Keyboard.Enums;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;
using NeatInput.Windows.Events;

using System.Linq;
using System.Collections.Generic;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class State : IProcessingStep<KBDLLHOOKSTRUCT, KeyboardEvent>
    {
        private readonly Dictionary<KeyStates, List<WindowsMessages>> _stateMessagesMap;

        internal State()
        {
            _stateMessagesMap = new Dictionary<KeyStates, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
        }

        public ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> Process(
            ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> valueTransformation)
        {
            valueTransformation.Output.State = GetState(valueTransformation.Message);
            return valueTransformation;
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
               WindowsMessages.WM_KEYDOWN,
               WindowsMessages.WM_SYSKEYDOWN
            };

            _stateMessagesMap.Add(KeyStates.Down, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
               WindowsMessages.WM_KEYUP,
               WindowsMessages.WM_SYSKEYUP
            };

            _stateMessagesMap.Add(KeyStates.Up, messages);
        }
    }
}
