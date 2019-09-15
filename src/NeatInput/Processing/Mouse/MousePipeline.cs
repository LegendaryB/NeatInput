using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;

namespace NeatInput.Processing.Mouse
{
    internal class MousePipeline : Pipeline<MouseInput, MSLLHOOKSTRUCT>
    {
        internal MousePipeline()
        {
            _pipeline.Add(new KeyProcessor());
            _pipeline.Add(new StateProcessor());
            _pipeline.Add(new XButtonProcessor());
            _pipeline.Add(new WheelProcessor());
        }

        public override void Process(ref MouseInput input, WindowsMessages msg, MSLLHOOKSTRUCT @struct)
        {
            input.X = @struct.pt.X;
            input.Y = @struct.pt.Y;

            foreach (var _pipelineElement in _pipeline)
            {
                _pipelineElement.Process(
                    ref input,
                    msg,
                    @struct);
            }
        }
    }
}
