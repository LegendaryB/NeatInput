﻿using System;
using System.Runtime.InteropServices;

namespace NeatInput.Windows.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        IntPtr hwnd;
        uint message;
        UIntPtr wParam;
        IntPtr lParam;
        int time;
        POINT pt;
    }
}