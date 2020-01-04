using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows.Events
{
    public class KeyboardEvent : InputEvent
    {
        public KeyCodes Key { get; internal set; }
        public KeyStates State { get; internal set; }
    }
}
