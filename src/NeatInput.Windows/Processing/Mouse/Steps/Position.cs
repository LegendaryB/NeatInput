using NeatInput.Windows.Events;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class Position : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            valueTransformation.Output.Position = valueTransformation.Input.pt;
            return valueTransformation;
        }
    }
}
