using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Processing;

namespace NeatInput.Hooking
{
    internal class Keyboard : InputHook<KeyboardInput, KBDLLHOOKSTRUCT, KeyboardInputPipeline>
    {
        protected override int HookID => 13; // WH_KEYBOARD_LL
    }
}
