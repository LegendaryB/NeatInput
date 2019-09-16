using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Processing;

namespace NeatInput.Hooking
{
    internal class Mouse : Hook<MouseInput, MSLLHOOKSTRUCT, MouseInputPipeline>
    {
        protected override int HookID => 14; // WH_MOUSE_LL
    }
}
