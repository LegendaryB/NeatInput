using NeatInput.Windows.Processing.Mouse.Enums;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Events
{
    public class MouseEvent : InputEvent
    {
        public MouseKeys Key { get; internal set; }
        public MouseStates State { get; internal set; }
        public POINT Position { get; internal set; }
    }
}
