using NeatInput.Windows.Events;

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
