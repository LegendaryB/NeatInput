using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Ole32
    {
        [DllImport(Libraries.Ole32, ExactSpelling = true)]
        public static extern HRESULT CoRegisterMessageFilter(
            IntPtr lpMessageFilter,
            ref IntPtr lplpMessageFilter);
    }
}
