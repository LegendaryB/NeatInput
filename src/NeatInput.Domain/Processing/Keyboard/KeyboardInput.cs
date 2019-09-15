using NeatInput.Domain.Processing.Keyboard.Enums;

namespace NeatInput.Domain.Processing.Keyboard
{
    public class KeyboardInput :
        Input
    {
        public KeyCodes Key { get; set; }
        public KeyStates State { get; set; }
    }
}
