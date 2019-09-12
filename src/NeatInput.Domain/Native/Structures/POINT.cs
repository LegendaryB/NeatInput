using System.Runtime.InteropServices;

namespace NeatInput.Domain.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
}
