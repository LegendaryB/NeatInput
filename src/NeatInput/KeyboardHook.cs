namespace NeatInput
{
    public sealed class KeyboardHook : InputHookBase
    {
        protected override int HookID => 13; // WH_KEYBOARD_LL

        internal KeyboardHook()
        {
            SetHook();
        }
    }
}
