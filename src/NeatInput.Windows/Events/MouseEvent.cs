using NeatInput.Windows.Processing.Mouse.Enums;

namespace NeatInput.Windows.Events
{
    public class MouseEvent : InputEvent
    {
        public MouseKeys Key { get; internal set; }
        public MouseStates State { get; internal set; }
    }
}
