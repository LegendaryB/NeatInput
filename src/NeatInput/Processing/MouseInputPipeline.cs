using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Processing.Mouse;

namespace NeatInput.Processing
{
    internal class MouseInputPipeline : InputPipeline<MouseInput, MSLLHOOKSTRUCT>
    {
        public MouseInputPipeline()
        {
            _pipeline.Add(new KeyProcessor());
            _pipeline.Add(new StateProcessor());
            _pipeline.Add(new XButtonProcessor());
            _pipeline.Add(new WheelProcessor());
        }

        public override MouseInput Process(WindowsMessages msg, MSLLHOOKSTRUCT @struct)
        {
            var input = new MouseInput
            {
                X = @struct.pt.X,
                Y = @struct.pt.Y
            };

            if (@struct.flags == MSLLHOOKSTRUCTFlags.LLMHF_INJECTED || @struct.flags == MSLLHOOKSTRUCTFlags.LLMHF_LOWER_IL_INJECTED)
                input.WasSimulated = true;

            foreach (var _pipelineElement in _pipeline)
            {
                _pipelineElement.Process(
                    ref input,
                    msg,
                    @struct);
            }

            return input;
        }
    }
}
