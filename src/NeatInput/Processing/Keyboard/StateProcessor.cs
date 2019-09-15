using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Keyboard.Enums;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Processing.Keyboard
{
    internal class StateProcessor : IInputProcessor<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        private readonly Dictionary<KeyStates, List<WindowsMessages>> _stateMessagesMap;

        internal StateProcessor()
        {
            _stateMessagesMap = new Dictionary<KeyStates, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
        }

        public void Process(
            ref KeyboardInput input, 
            WindowsMessages msg, 
            KBDLLHOOKSTRUCT @struct)
        {
            input.State = GetState(msg);
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
