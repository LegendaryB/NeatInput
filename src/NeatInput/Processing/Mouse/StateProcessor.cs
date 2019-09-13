using NeatInput.Application.Processing.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Mouse;
using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Processing.Mouse
{
    internal class StateProcessor :
        IMouseInputProcessor
    {
        private readonly Dictionary<MouseState, List<WindowsMessages>> _stateMessagesMap;

        public StateProcessor()
        {
            _stateMessagesMap = new Dictionary<MouseState, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
            RegisterMoveStateMessages();
        }

        public void Process(
            ref MouseInput input,
            WindowsMessages msg,
            MSLLHOOKSTRUCT msllhookstruct)
        {
            input.State = GetState(msg);
        }

        private MouseState GetState(WindowsMessages msg)
        {
            return _stateMessagesMap
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

            _stateMessagesMap.Add(MouseState.KeyDown, messages);
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

            _stateMessagesMap.Add(MouseState.KeyUp, messages);
        }

        private void RegisterMoveStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEMOVE,
                WindowsMessages.WM_NCSMOUSEMOVE
            };

            _stateMessagesMap.Add(MouseState.Moving, messages);
        }
    }
}
