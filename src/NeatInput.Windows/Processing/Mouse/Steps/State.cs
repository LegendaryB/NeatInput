using static Interop.User32;
using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class State : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        private readonly Dictionary<MouseStates, List<WindowMessage>> _map =
            new Dictionary<MouseStates, List<WindowMessage>>();

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

        private MouseStates GetState(WindowMessage msg)
        {
            return _map
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterDownStateMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_LBUTTONDOWN,
                WindowMessage.WM_NCLBUTTONDOWN,
                WindowMessage.WM_RBUTTONDOWN,
                WindowMessage.WM_NCRBUTTONDOWN,
                WindowMessage.WM_MBUTTONDOWN,
                WindowMessage.WM_NCMBUTTONDOWN,
                WindowMessage.WM_XBUTTONDOWN,
                WindowMessage.WM_NCXBUTTONDOWN
            };

            _map.Add(MouseStates.KeyDown, messages);
        }

        private void RegisterUpStateMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_LBUTTONUP,
                WindowMessage.WM_NCLBUTTONUP,
                WindowMessage.WM_RBUTTONUP,
                WindowMessage.WM_NCRBUTTONUP,
                WindowMessage.WM_MBUTTONUP,
                WindowMessage.WM_NCMBUTTONUP,
                WindowMessage.WM_XBUTTONUP,
                WindowMessage.WM_NCXBUTTONUP
            };

            _map.Add(MouseStates.KeyUp, messages);
        }

        private void RegisterMoveStateMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_MOUSEMOVE,
                WindowMessage.WM_NCSMOUSEMOVE
            };

            _map.Add(MouseStates.Move, messages);
        }
    }
}
