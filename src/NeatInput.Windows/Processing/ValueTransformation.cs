namespace NeatInput.Windows.Processing
{
    internal class ValueTransformation<TInput, TOutput>
        where TInput : struct
        where TOutput : class
    {
        internal WindowsMessages Message { get; set; }
        internal TInput Input { get; set; }
        internal TOutput Output { get; set; }
    }
}
