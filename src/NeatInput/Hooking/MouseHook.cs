using NeatInput.Application.Hooking;

namespace NeatInput.Hooking
{
    internal class MouseHook : InputHook,
        IMouseHook
    {
        protected override int HookID => WH_MOUSE_LL;
    }
}
