using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Steps;

namespace NeatInput.Windows.Processing
{
    internal class MouseProcessor : InputProcessor<MSLLHOOKSTRUCT, MouseEvent>
    {
        internal MouseProcessor()
        {
            ProcessingSteps.Add(new Key());
            ProcessingSteps.Add(new State());
            ProcessingSteps.Add(new Position());            
            ProcessingSteps.Add(new Simulated());
            ProcessingSteps.Add(new Wheel());
            ProcessingSteps.Add(new XButton());
        }
    }
}
