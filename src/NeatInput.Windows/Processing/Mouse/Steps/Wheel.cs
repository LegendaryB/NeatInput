using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class Wheel : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            if (valueTransformation.Output.Key != MouseKeys.WHEEL)
            {
                return valueTransformation;
            }

            if (Helper.HIWORD(valueTransformation.Input.mouseData) > 0)
            {
                valueTransformation.Output.State = MouseStates.KeyUp;
                return valueTransformation;
            }

            return valueTransformation;
        }
    }
}
