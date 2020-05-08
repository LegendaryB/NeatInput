using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows.Events
{
    public class KeyboardEvent : InputEvent
    {
        /// <summary>
        /// The key which caused the event. 
        /// </summary>
        public Keys Key { get; internal set; }

        /// <summary>
        /// The state of the key which caused the event.
        /// </summary>
        public KeyStates State { get; internal set; }
    }
}
