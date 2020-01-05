using NeatInput.Windows.Processing.Mouse.Enums;

namespace NeatInput.Windows.Events
{
    public class MouseEvent : InputEvent
    {
        /// <summary>
        /// The key which caused the event.
        /// </summary>
        public MouseKeys Key { get; internal set; }

        /// <summary>
        /// The state of the key which caused the event.
        /// </summary>
        public MouseStates State { get; internal set; }

        /// <summary>
        /// The x coordinate of the mouse cursor on the screen.
        /// </summary>
        public int X { get; internal set; }

        /// <summary>
        /// The y coordinate of the mouse cursor on the screen.
        /// </summary>
        public int Y { get; internal set; }
    }
}
