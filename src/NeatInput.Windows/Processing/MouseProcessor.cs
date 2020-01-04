using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Steps;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Processing
{
    internal class MouseProcessor : InputProcessor<MSLLHOOKSTRUCT, MouseEvent>
    {
        internal MouseProcessor()
        {
            ProcessingSteps.Add(new Key());
            ProcessingSteps.Add(new Simulated());
        }
    }
}
