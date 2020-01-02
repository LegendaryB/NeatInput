using NeatInput.Windows.Processing.Keyboard;
using NeatInput.Windows.Processing.Keyboard.Steps;

using Paipurain.Handler;

namespace NeatInput.Windows.Processing
{
    internal class KeyboardProcessor : Builder<ValueWrapper>
    {
        internal KeyboardProcessor()
        {
            AddBlock(new PressedKey());
            AddBlock(new State());
        }
    }
}
