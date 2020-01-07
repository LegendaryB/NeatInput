internal static partial class Interop
{
    internal static partial class User32
    {
        public enum HC : int
        {
            ACTION = 0,
            GETNEXT = 1,
            SKIP = 2,
            NOREMOVE = 3,
            NOREM = NOREMOVE,
            SYSMODALON = 4,
            SYSMODALOFF = 5,
        }
    }
}
