using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows.Events
{
    public class KeyboardEvent
    {
        public KeyCodes Key { get; set; }
        public KeyStates State { get; set; }
    }
}
