namespace NeatInput.Processing.Mouse
{
    internal static class ProcessorHelpers
    {
        internal static short HIWORD(uint value)
        {
            return (short)((value >> 16));
        }
    }
}
