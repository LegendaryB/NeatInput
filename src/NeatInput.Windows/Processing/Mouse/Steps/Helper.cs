namespace NeatInput.Windows.Processing.Mouse.Steps
{
    internal static class Helper
    {
        internal static short HIWORD(uint value)
        {
            return (short)((value >> 16));
        }
    }
}
