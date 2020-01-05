using System.Runtime.InteropServices;

namespace NeatInput.Windows.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
}
