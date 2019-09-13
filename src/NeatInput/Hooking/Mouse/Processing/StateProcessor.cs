using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Hooking.Mouse.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Hooking.Mouse.Processing
{
    internal class StateProcessor :
        IMouseInputProcessor
    {
        private readonly Dictionary<KeyState, List<WindowsMessages>> _stateMessagesMap;

        public StateProcessor()
        {
            _stateMessagesMap = new Dictionary<KeyState, List<WindowsMessages>>();

            RegisterDownStateMessages();
            RegisterUpStateMessages();
            RegisterPressedStateMessages();
            RegisterMoveStateMessages();
        }

        public void Process(
            ref MouseInput input,
            WindowsMessages msg,
            MSLLHOOKSTRUCT msllhookstruct)
        {
            input.State = GetState(msg);
        }

        private KeyState GetState(WindowsMessages msg)
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

            _stateMessagesMap.Add(KeyState.Down, messages);
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

            _stateMessagesMap.Add(KeyState.Up, messages);
        }

        private void RegisterPressedStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEWHEEL,
                WindowsMessages.WM_MOUSEHWHEEL
            };

            _stateMessagesMap.Add(KeyState.Pressed, messages);
        }

        private void RegisterMoveStateMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEMOVE,
                WindowsMessages.WM_NCSMOUSEMOVE
            };

            _stateMessagesMap.Add(KeyState.Move, messages);
        }
    }
}
