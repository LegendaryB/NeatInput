using NeatInput.Windows.Interop;

using System;
using System.Drawing;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public WindowMessage message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;

            public static implicit operator Message(MSG msg)
                => new Message { HWnd = msg.hwnd, Msg = (int)msg.message, WParam = msg.wParam, LParam = msg.lParam };

            public static implicit operator MSG(Message message)
                => new MSG { hwnd = message.HWnd, message = (WindowMessage)message.Msg, wParam = message.WParam, lParam = message.LParam };
        }
    }
}
