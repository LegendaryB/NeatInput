using NeatInput.Application.Hooking;

namespace NeatInput.Infrastructure.Hooking
{
    public class MouseHook : InputHook,
        IMouseHook
    {
        protected override int HookID => WH_MOUSE_LL;
    }
}
