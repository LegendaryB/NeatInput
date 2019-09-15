using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Keyboard.Enums;
using NeatInput.Processing.Keyboard;

using System.Runtime.InteropServices;

namespace NeatInput.Processing
{
    internal class KeyboardPipeline : Pipeline<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        internal KeyboardPipeline()
        {
            _pipeline.Add(new StateProcessor());
        }

        public override KeyboardInput Process(WindowsMessages msg, KBDLLHOOKSTRUCT @struct)
        {
            var input = new KeyboardInput
            {
                IsSimulated = @struct.flags == KBDLLHOOKSTRUCTFlags.LLKHF_INJECTED,
                Key = (KeyCodes)@struct.vkCode
            };

            return input;
        }
    }
}
