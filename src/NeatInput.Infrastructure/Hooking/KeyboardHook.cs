using NeatInput.Application.Hooking;

namespace NeatInput.Infrastructure.Hooking
{
    public class KeyboardHook : InputHook,
        IKeyboardHook
    {
        protected override int HookID => WH_KEYBOARD_LL;
    }
}
