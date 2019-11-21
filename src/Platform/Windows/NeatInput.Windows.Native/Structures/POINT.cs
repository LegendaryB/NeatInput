using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
}
