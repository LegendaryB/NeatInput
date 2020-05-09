namespace NeatInput.Windows.Processing
{
    internal static class InputProcessorProvider
    {
        internal static KeyboardProcessor Keyboard = new KeyboardProcessor();
        internal static MouseProcessor Mouse = new MouseProcessor();
    }
}
