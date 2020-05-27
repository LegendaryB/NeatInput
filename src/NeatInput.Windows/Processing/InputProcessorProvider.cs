namespace NeatInput.Windows.Processing
{
    internal static class InputProcessorProvider
    {
        internal static readonly KeyboardProcessor Keyboard = new KeyboardProcessor();
        internal static readonly MouseProcessor Mouse = new MouseProcessor();
    }
}
