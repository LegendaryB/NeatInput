using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Domain.Processing.Mouse.Enums;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Processing.Mouse
{
    internal class KeyProcessor : IInputProcessor<MouseInput, MSLLHOOKSTRUCT>
    {
        private readonly Dictionary<MouseKeys, List<WindowsMessages>> _buttonMessagesMap;

        internal KeyProcessor()
        {
            _buttonMessagesMap = new Dictionary<MouseKeys, List<WindowsMessages>>();

            RegisterLeftButtonMessages();
            RegisterRightButtonMessages();
            RegisterMiddleButtonMessages();
            RegisterXButtonMessages();
            RegisterWheelMessages();
            RegisterScanningDeviceMessages();
        }

        public void Process(
            ref MouseInput input,
            WindowsMessages msg,
            MSLLHOOKSTRUCT msllhookstruct)
        {
            input.Key = GetKey(msg);
        }

        private MouseKeys GetKey(WindowsMessages msg)
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

            _buttonMessagesMap.Add(MouseKeys.LBUTTON, messages);
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

            _buttonMessagesMap.Add(MouseKeys.RBUTTON, messages);
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

            _buttonMessagesMap.Add(MouseKeys.MBUTTON, messages);
        }

        private void RegisterXButtonMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_XBUTTONDOWN,
                WindowsMessages.WM_XBUTTONUP,
                WindowsMessages.WM_NCXBUTTONDOWN,
                WindowsMessages.WM_NCXBUTTONUP
            };

            _buttonMessagesMap.Add(MouseKeys.XBUTTON1, messages);
        }

        private void RegisterWheelMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEWHEEL,
                WindowsMessages.WM_MOUSEHWHEEL
            };

            _buttonMessagesMap.Add(MouseKeys.WHEEL, messages);
        }

        private void RegisterScanningDeviceMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEMOVE,
                WindowsMessages.WM_NCSMOUSEMOVE
            };

            _buttonMessagesMap.Add(MouseKeys.SCANDEVICE, messages);
        }
    }
}
