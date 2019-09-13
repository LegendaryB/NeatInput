namespace NeatInput.Domain.Processing.Mouse
{
    public class MouseInput : Input
    {
        public MouseState State { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
