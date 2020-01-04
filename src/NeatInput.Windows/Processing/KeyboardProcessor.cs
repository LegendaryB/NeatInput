using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Keyboard.Steps;
using NeatInput.Windows.Win32.Structs;

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
