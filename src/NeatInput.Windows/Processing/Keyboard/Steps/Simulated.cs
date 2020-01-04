using NeatInput.Windows.Events;
using NeatInput.Windows.Win32.Enums.Flags;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class Simulated : IProcessingStep<KBDLLHOOKSTRUCT, KeyboardEvent>
    {
        public ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> Process(
            ValueTransformation<KBDLLHOOKSTRUCT, KeyboardEvent> valueTransformation)
        {
            valueTransformation.Output.HasBeenSimulated = valueTransformation.Input.flags == KBDLLHOOKSTRUCTFlags.LLKHF_INJECTED;
            return valueTransformation;
        }
    }
}
