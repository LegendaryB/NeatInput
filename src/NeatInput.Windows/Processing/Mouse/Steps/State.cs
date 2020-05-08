using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class State : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        private readonly Dictionary<MouseStates, List<WindowsMessages>> _map =
            new Dictionary<MouseStates, List<WindowsMessages>>();

        internal State()
        {
            RegisterDownStateMessages();
            RegisterUpStateMessages();
            RegisterMoveStateMessages();
        }

        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            valueTransformation.Output.State = GetState(valueTransformation.Message);
            return valueTransformation;
        }

        private MouseStates GetState(WindowsMessages msg)
        {
            return _map
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterDownStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_LBUTTONDOWN,
                WindowsMessages.WM_NCLBUTTONDOWN,
                WindowsMessages.WM_RBUTTONDOWN,
                WindowsMessages.WM_NCRBUTTONDOWN,
                WindowsMessages.WM_MBUTTONDOWN,
                WindowsMessages.WM_NCMBUTTONDOWN,
                WindowsMessages.WM_XBUTTONDOWN,
                WindowsMessages.WM_NCXBUTTONDOWN
            };

            _map.Add(MouseStates.KeyDown, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_LBUTTONUP,
                WindowsMessages.WM_NCLBUTTONUP,
                WindowsMessages.WM_RBUTTONUP,
                WindowsMessages.WM_NCRBUTTONUP,
                WindowsMessages.WM_MBUTTONUP,
                WindowsMessages.WM_NCMBUTTONUP,
                WindowsMessages.WM_XBUTTONUP,
                WindowsMessages.WM_NCXBUTTONUP
            };

            _map.Add(MouseStates.KeyUp, messages);
        }

        private void RegisterMoveStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEMOVE,
                WindowsMessages.WM_NCSMOUSEMOVE
            };

            _map.Add(MouseStates.Move, messages);
        }
    }
}
