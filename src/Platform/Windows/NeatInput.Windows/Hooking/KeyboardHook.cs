using NeatInput.Windows.Native.Enumerations;

namespace NeatInput.Windows.Hooking
{
    internal class KeyboardHook : Hook
    {
        protected override HookType Type => HookType.WH_KEYBOARD_LL;
    }
}
