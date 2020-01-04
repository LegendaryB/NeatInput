using NeatInput.Windows.Events;

namespace NeatInput.Windows.Processing
{
    internal interface IProcessingStep<TInput, TOutput>
        where TInput : struct
        where TOutput : InputEvent
    {
        ValueTransformation<TInput, TOutput> Process(
            ValueTransformation<TInput, TOutput> valueTransformation);
    }
}
