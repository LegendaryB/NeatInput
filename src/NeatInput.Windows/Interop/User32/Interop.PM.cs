using System;

internal static partial class Interop
{
    internal static partial class User32
    {
        [Flags]
        public enum PM : uint
        {
            NOREMOVE = 0x0000,
            REMOVE = 0x0001,
            NOYIELD = 0x0002
        }
    }
}
