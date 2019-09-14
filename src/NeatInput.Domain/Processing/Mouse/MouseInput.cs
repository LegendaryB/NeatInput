using NeatInput.Domain.Processing.Mouse.Enums;

namespace NeatInput.Domain.Processing.Mouse
{
    public class MouseInput : Input
    {
        public MouseKeys Key { get; set; }
        public MouseStates State { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
