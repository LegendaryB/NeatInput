using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows
{
    public class KeyboardEvent
    {
        public KeyCodes Key { get; set; }
        public KeyStates State { get; set; }
    }
}
