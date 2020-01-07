using static Interop.User32;
using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class Key : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        private readonly Dictionary<MouseKeys, List<WindowMessage>> _map =
            new Dictionary<MouseKeys, List<WindowMessage>>();

        internal Key()
        {
            RegisterLeftButtonMessages();
            RegisterRightButtonMessages();
            RegisterMiddleButtonMessages();
            RegisterXButtonMessages();
            RegisterWheelMessages();
            RegisterScanningDeviceMessages();
        }

        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            valueTransformation.Output.Key = GetKey(valueTransformation.Message);
            return valueTransformation;
        }

        private MouseKeys GetKey(WindowMessage msg)
        {
            return _map
                .FirstOrDefault(kvp => kvp.Value.Contains(msg))
                .Key;
        }

        private void RegisterLeftButtonMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_LBUTTONDOWN,
                WindowMessage.WM_LBUTTONUP,
                WindowMessage.WM_NCLBUTTONDOWN,
                WindowMessage.WM_NCLBUTTONUP
            };

            _map.Add(MouseKeys.LBUTTON, messages);
        }

        private void RegisterRightButtonMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_RBUTTONDOWN,
                WindowMessage.WM_RBUTTONUP,
                WindowMessage.WM_NCRBUTTONDOWN,
                WindowMessage.WM_NCRBUTTONUP
            };

            _map.Add(MouseKeys.RBUTTON, messages);
        }

        private void RegisterMiddleButtonMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_MBUTTONDOWN,
                WindowMessage.WM_MBUTTONUP,
                WindowMessage.WM_NCMBUTTONDOWN,
                WindowMessage.WM_NCMBUTTONUP
            };

            _map.Add(MouseKeys.MBUTTON, messages);
        }

        private void RegisterXButtonMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_XBUTTONDOWN,
                WindowMessage.WM_XBUTTONUP,
                WindowMessage.WM_NCXBUTTONDOWN,
                WindowMessage.WM_NCXBUTTONUP
            };

            _map.Add(MouseKeys.XBUTTON1, messages);
        }

        private void RegisterWheelMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_MOUSEWHEEL,
                WindowMessage.WM_MOUSEHWHEEL
            };

            _map.Add(MouseKeys.WHEEL, messages);
        }

        private void RegisterScanningDeviceMessages()
        {
            var messages = new List<WindowMessage>
            {
                WindowMessage.WM_MOUSEMOVE,
                WindowMessage.WM_NCSMOUSEMOVE
            };

            _map.Add(MouseKeys.SCANDEVICE, messages);
        }
    }
}