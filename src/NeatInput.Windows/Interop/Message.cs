using static Interop.User32;

using System;

namespace NeatInput.Windows.Interop
{
    public struct Message
    {
        public IntPtr HWnd { get; internal set; }
        public int Msg { get; internal set; }
        public IntPtr WParam { get; internal set; }
        public IntPtr LParam { get; internal set; }
        public IntPtr Result { get; internal set; }

        internal static Message Create(IntPtr hWnd, WindowMessage msg, IntPtr wparam, IntPtr lparam)
            => Create(hWnd, (int)msg, wparam, lparam);

        internal static Message Create(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            var m = new Message
            {
                HWnd = hWnd,
                Msg = msg,
                WParam = wparam,
                LParam = lparam,
                Result = IntPtr.Zero
            };

            return m;
        }

        public override bool Equals(object o)
        {
            if (!(o is Message m))
            {
                return false;
            }

            return HWnd == m.HWnd &&
                   Msg == m.Msg &&
                   WParam == m.WParam &&
                   LParam == m.LParam &&
                   Result == m.Result;
        }

        public static bool operator ==(Message a, Message b) => a.Equals(b);

        public static bool operator !=(Message a, Message b) => !a.Equals(b);

        public override int GetHashCode() => HashCode.Combine(HWnd, Msg);
    }
}
