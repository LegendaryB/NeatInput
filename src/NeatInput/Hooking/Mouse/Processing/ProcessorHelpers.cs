namespace NeatInput.Hooking.Mouse.Processing
{
    internal static class ProcessorHelpers
    {
        internal static short HIWORD(uint value)
        {
            return (short)((value >> 16));
        }
    }
}
