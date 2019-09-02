using NeatInput.Win32.Structures.User32;

using System;
using System.Runtime.InteropServices;

namespace NeatInput.Win32
{
    internal class User32
    {
        internal delegate IntPtr InputHookHandler(
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam);        

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(
            int idHook,
            InputHookHandler lpfn, 
            IntPtr hMod, 
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk, 
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
           uint wMsgFilterMax);

        [DllImport("user32.dll")]
        internal static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        internal static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport("user32.dll")]
        internal static extern short VkKeyScan(char ch);
    }
}
