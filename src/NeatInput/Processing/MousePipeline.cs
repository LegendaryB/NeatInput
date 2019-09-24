using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Processing.Mouse;

namespace NeatInput.Processing
{
    internal class MousePipeline : InputPipeline<MouseInput, MSLLHOOKSTRUCT>
    {
        public MousePipeline()
        {
            _pipeline.Add(new KeyProcessor());
            _pipeline.Add(new StateProcessor());
            _pipeline.Add(new XButtonProcessor());
            _pipeline.Add(new WheelProcessor());
            _pipeline.Add(new CoordinatesProcessor());
            _pipeline.Add(new InjectedFlagProcessor());            
        }
    }
}
