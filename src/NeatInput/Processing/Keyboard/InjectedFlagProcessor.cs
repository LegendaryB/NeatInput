using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;

namespace NeatInput.Processing.Keyboard
{
    internal class InjectedFlagProcessor : IInputProcessor<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        public void Process(
            ref KeyboardInput input, 
            WindowsMessages msg, 
            KBDLLHOOKSTRUCT @struct)
        {
            input.WasSimulated = @struct.flags == KBDLLHOOKSTRUCTFlags.LLKHF_INJECTED;
        }
    }
}
