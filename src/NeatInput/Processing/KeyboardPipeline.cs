using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Processing.Keyboard;

namespace NeatInput.Processing
{
    internal class KeyboardInputPipeline : InputPipeline<KeyboardInput, KBDLLHOOKSTRUCT>
    {
        public KeyboardInputPipeline()
        {
            _pipeline.Add(new KeyProcessor());
            _pipeline.Add(new StateProcessor());
        }
    }
}
