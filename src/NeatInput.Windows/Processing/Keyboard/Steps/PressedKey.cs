using NeatInput.Windows.Events;
using NeatInput.Windows.Processing.Keyboard.Enums;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class PressedKey : IProcessingStep<KBDLLHOOKSTRUCT, KeyboardEvent>
    {
        public ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> Process(
            ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> valueTransformation)
        {
            valueTransformation.Output.Key = (Keys)valueTransformation.Input.vkCode;
            return valueTransformation;
        }
    }
}
