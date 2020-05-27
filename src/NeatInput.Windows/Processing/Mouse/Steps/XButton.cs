using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Mouse.Enums;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class XButton : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            if (valueTransformation.Output.Key != MouseKeys.XBUTTON1)
            {
                return valueTransformation;
            }

            if (Helper.HIWORD(valueTransformation.Input.mouseData) == 2)
            {
                valueTransformation.Output.Key = MouseKeys.XBUTTON2;
            }

            return valueTransformation;
        }
    }
}
