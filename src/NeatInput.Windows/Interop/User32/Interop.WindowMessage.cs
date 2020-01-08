internal static partial class Interop
{
    internal static partial class User32
    {
        internal enum WindowMessage : uint
        {
            WM_NULL = 0x000,            
            
            WM_KEYFIRST = WM_KEYDOWN,
            WM_KEYDOWN = 0x100,
            WM_SYSKEYDOWN = 0x104,
            WM_KEYUP = 0x101,
            WM_SYSKEYUP = 0x105,

            WM_MOUSEFIRST = 0x200,
            WM_LBUTTONDOWN = 0x0201,
            WM_NCLBUTTONDOWN = 0x00A1,
            WM_LBUTTONUP = 0x0202,
            WM_NCLBUTTONUP = 0x00A2,

            WM_RBUTTONDOWN = 0x0204,
            WM_NCRBUTTONDOWN = 0x00A4,
            WM_RBUTTONUP = 0x0205,
            WM_NCRBUTTONUP = 0x00A5,

            WM_MBUTTONDOWN = 0x0207,
            WM_NCMBUTTONDOWN = 0x00A7,
            WM_MBUTTONUP = 0x0208,
            WM_NCMBUTTONUP = 0x00A8,

            WM_XBUTTONDOWN = 0x020B,
            WM_NCXBUTTONDOWN = 0x00AB,
            WM_XBUTTONUP = 0x020C,
            WM_NCXBUTTONUP = 0x00AC,

            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEHWHEEL = 0x020E,

            WM_MOUSEMOVE = 0x0200,
            WM_NCSMOUSEMOVE = 0x00A0
        }
    }
}