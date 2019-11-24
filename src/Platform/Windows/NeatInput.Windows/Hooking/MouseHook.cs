using NeatInput.Windows.Native.Enumerations;

namespace NeatInput.Windows.Hooking
{
    internal class MouseHook : Hook
    {
        protected override HookType Type => HookType.WH_MOUSE_LL;
    }
}
