using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;
using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

using System.Collections.Generic;
using System.Linq;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class Key : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        private readonly Dictionary<MouseKeys, List<WindowsMessages>> _map =
            new Dictionary<MouseKeys, List<WindowsMessages>>();

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

        private MouseKeys GetKey(WindowsMessages msg)
        {
            return _map
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

            _map.Add(MouseKeys.LBUTTON, messages);
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

            _map.Add(MouseKeys.RBUTTON, messages);
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

            _map.Add(MouseKeys.MBUTTON, messages);
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

            _map.Add(MouseKeys.XBUTTON1, messages);
        }

        private void RegisterWheelMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEWHEEL,
                WindowsMessages.WM_MOUSEHWHEEL
            };

            _map.Add(MouseKeys.WHEEL, messages);
        }

        private void RegisterScanningDeviceMessages()
        {
            var messages = new List<WindowsMessages>
            {
                WindowsMessages.WM_MOUSEMOVE,
                WindowsMessages.WM_NCSMOUSEMOVE
            };

            _map.Add(MouseKeys.SCANDEVICE, messages);
        }
    }
}