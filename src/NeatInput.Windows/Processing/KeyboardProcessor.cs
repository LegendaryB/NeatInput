using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Keyboard.Steps;

namespace NeatInput.Windows.Processing
{
    internal class KeyboardProcessor : InputProcessor<KBDLLHOOKSTRUCT, KeyboardEvent>
    {
        internal KeyboardProcessor()
        {
            ProcessingSteps.Add(new PressedKey());
            ProcessingSteps.Add(new State());
            ProcessingSteps.Add(new Simulated());
        }
    }
}
