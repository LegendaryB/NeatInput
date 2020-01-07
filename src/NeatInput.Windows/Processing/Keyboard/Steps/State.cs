using static Interop.User32;
using NeatInput.Windows.Processing.Keyboard.Enums;
using NeatInput.Windows.Events;

using System.Linq;
using System.Collections.Generic;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class State : IProcessingStep<KBDLLHOOKSTRUCT, KeyboardEvent>
    {
        private readonly Dictionary<KeyStates, List<WindowMessage>> _stateMessagesMap;

        internal State()
        {
            _stateMessagesMap = new Dictionary<KeyStates, List<WindowMessage>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
        }

        public ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> Process(
            ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> valueTransformation)
        {
            valueTransformation.Output.State = GetState(valueTransformation.Message);
            return valueTransformation;
        }

        private KeyStates GetState(WindowMessage msg)
        {
            return _stateMessagesMap
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterDownStateMessages()
        {
            var messages = new List<WindowMessage>
            {
               WindowMessage.WM_KEYDOWN,
               WindowMessage.WM_SYSKEYDOWN
            };

            _stateMessagesMap.Add(KeyStates.Down, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowMessage>
            {
               WindowMessage.WM_KEYUP,
               WindowMessage.WM_SYSKEYUP
            };

            _stateMessagesMap.Add(KeyStates.Up, messages);
        }
    }
}
