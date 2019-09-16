using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Keyboard.Enums;
using NeatInput.Processing.Keyboard;

namespace NeatInput.Processing
{
    internal class KeyboardInputPipeline : InputPipeline<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        public KeyboardInputPipeline()
        {
            _pipeline.Add(new StateProcessor());
        }

        public override KeyboardInput Process(WindowsMessages msg, KBDLLHOOKSTRUCT @struct)
        {
            var input = new KeyboardInput
            {
                WasSimulated = @struct.flags == KBDLLHOOKSTRUCTFlags.LLKHF_INJECTED,
                Key = (KeyCodes)@struct.vkCode
            };

            return input;
        }
    }
}
