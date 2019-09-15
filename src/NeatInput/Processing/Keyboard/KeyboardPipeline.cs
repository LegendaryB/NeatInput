using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;

namespace NeatInput.Processing.Keyboard
{
    internal class KeyboardPipeline : Pipeline<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        internal KeyboardPipeline()
        {

        }

        public override KeyboardInput Process(WindowsMessages msg, KBDLLHOOKSTRUCT @struct)
        {
            throw new System.NotImplementedException();
        }
    }
}
