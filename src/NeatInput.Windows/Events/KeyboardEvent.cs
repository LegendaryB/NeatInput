using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows.Events
{
    public class KeyboardEvent : InputEvent
    {
        public Keys Key { get; internal set; }
        public KeyStates State { get; internal set; }
    }
}
