namespace NeatInput.Windows.Processing
{
    internal interface IProcessingStep<TInput, TOutput>
        where TInput : struct
        where TOutput : class
    {
        ValueTransformation<TInput, TOutput> Process(
            ValueTransformation<TInput, TOutput> valueTransformation);
    }
}
