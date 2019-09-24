using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;

namespace NeatInput.Processing.Mouse
{
    public class InjectedFlagProcessor : IInputProcessor<MouseInput, MSLLHOOKSTRUCT>
    {
        public void Process(
            ref MouseInput input,
            WindowsMessages msg, 
            MSLLHOOKSTRUCT @struct)
        {
            if (@struct.flags == MSLLHOOKSTRUCTFlags.LLMHF_INJECTED || @struct.flags == MSLLHOOKSTRUCTFlags.LLMHF_LOWER_IL_INJECTED)
                input.WasSimulated = true;
        }
    }
}
