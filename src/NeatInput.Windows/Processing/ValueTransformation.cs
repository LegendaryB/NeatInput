using static Interop.User32;

namespace NeatInput.Windows.Processing
{
    internal class ValueTransformation<TInput, TOutput>
        where TInput : struct
        where TOutput : class
    {
        internal WindowMessage Message { get; set; }
        internal TInput Input { get; set; }
        internal TOutput Output { get; set; }
    }
}
