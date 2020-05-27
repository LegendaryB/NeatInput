namespace NeatInput.Windows.Processing
{
    internal static class RawInputProcessor
    {
        internal static readonly KeyboardProcessor Keyboard = new KeyboardProcessor();
        internal static readonly MouseProcessor Mouse = new MouseProcessor();
    }
}
