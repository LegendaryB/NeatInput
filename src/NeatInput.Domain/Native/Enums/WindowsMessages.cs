namespace NeatInput.Domain.Native.Enums
{
    public enum WindowsMessages : uint
    {
        WM_KEYDOWN = 0x100,
        WM_SYSKEYDOWN = 0x104,
        WM_KEYUP = 0x101,
        WM_SYSKEYUP = 0x105,

        WM_LBUTTONDOWN = 0x0201,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_LBUTTONUP = 0x0202,
        WM_NCLBUTTONUP = 0x00A2,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_NCLBUTTONDBLCLK = 0x00A3,

        WM_RBUTTONDOWN = 0x0204,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_RBUTTONUP = 0x0205,
        WM_NCRBUTTONUP = 0x00A5,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        
        WM_MBUTTONDOWN = 0x0207,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_MBUTTONUP = 0x0208,
        WM_NCMBUTTONUP = 0x00A8,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_NCMBUTTONDBLCLK = 0x00A9,

        WM_XBUTTONDOWN = 0x020B,
        WM_NCXBUTTONDOWN = 0x00AB,
        WM_XBUTTONUP = 0x020C,
        WM_NCXBUTTONUP = 0x00AC,
        WM_XBUTTONDBLCLK = 0x020D,
        WM_NCXBUTTONDBLCLK = 0x00AD,

        WM_MOUSEMOVE = 0x0200,
        WM_NCSMOUSEMOVE = 0x00A0,
        WM_MOUSEWHEEL = 0x020A        
    }
}
