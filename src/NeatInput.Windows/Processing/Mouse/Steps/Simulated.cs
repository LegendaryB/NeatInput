using NeatInput.Windows.Events;

namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal class Simulated : IProcessingStep<MSLLHOOKSTRUCT, MouseEvent>
    {
        public ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> Process(
            ValueTransformation<MSLLHOOKSTRUCT, MouseEvent> valueTransformation)
        {
            if (valueTransformation.Input.flags == MSLLHOOKSTRUCTFlags.LLMHF_INJECTED || 
                valueTransformation.Input.flags == MSLLHOOKSTRUCTFlags.LLMHF_LOWER_IL_INJECTED)
            {
                valueTransformation.Output.HasBeenSimulated = true;
            }

            return valueTransformation;
        }
    }
}
