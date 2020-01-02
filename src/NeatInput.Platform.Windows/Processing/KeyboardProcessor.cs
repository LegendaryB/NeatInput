using NeatInput.Platform.Windows.Processing.Keyboard;
using NeatInput.Platform.Windows.Processing.Keyboard.Steps;

using Paipurain.Handler;

namespace NeatInput.Platform.Windows.Processing
{
    internal class KeyboardProcessor : Builder<ProcessingValueWrapper>
    {
        internal KeyboardProcessor()
        {
            AddBlock(new PressedKey());
            AddBlock(new State());
        }
    }
}
