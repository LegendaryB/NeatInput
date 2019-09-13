using NeatInput.Native.SafeHandles;

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace NeatInput.Native
{
    internal class User32
    {
        internal delegate IntPtr HookProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SetWindowsHookExSafeHandle SetWindowsHookEx(
            int idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport(@"user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetMessage(ref MSG message, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    }
}
