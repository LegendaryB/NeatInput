using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Mouse;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Hooking.Mouse
{
    internal class MouseKeyProcessor :
        IMouseInputProcessor
    {
        private readonly Dictionary<VirtualKeyCodes, List<WindowsMessages>> _buttonMessagesMap;

        public MouseKeyProcessor()
        {
            _buttonMessagesMap = new Dictionary<VirtualKeyCodes, List<WindowsMessages>>();

            RegisterLeftButtonMessages();
            RegisterRightButtonMessages();
            RegisterMiddleButtonMessages();
        }

        public void Process(
            ref MouseInput input,
            WindowsMessages msg,
            MSLLHOOKSTRUCT msllhookstruct)
        {
            input.Key = GetKey(msg);
        }

        private VirtualKeyCodes GetKey(WindowsMessages msg)
        {
            return _buttonMessagesMap
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterLeftButtonMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_LBUTTONDOWN,
                WindowsMessages.WM_LBUTTONUP,
                WindowsMessages.WM_NCLBUTTONDOWN,
                WindowsMessages.WM_NCLBUTTONUP
            };

            _buttonMessagesMap.Add(VirtualKeyCodes.LBUTTON, messages);
        }

        private void RegisterRightButtonMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_RBUTTONDOWN,
                WindowsMessages.WM_RBUTTONUP,
                WindowsMessages.WM_NCRBUTTONDOWN,
                WindowsMessages.WM_NCRBUTTONUP
            };

            _buttonMessagesMap.Add(VirtualKeyCodes.RBUTTON, messages);
        }

        private void RegisterMiddleButtonMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MBUTTONDOWN,
                WindowsMessages.WM_MBUTTONUP,
                WindowsMessages.WM_NCMBUTTONDOWN,
                WindowsMessages.WM_NCMBUTTONUP
            };

            _buttonMessagesMap.Add(VirtualKeyCodes.MBUTTON, messages);
        }
    }
}
