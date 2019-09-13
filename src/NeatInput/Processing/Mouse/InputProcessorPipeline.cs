using NeatInput.Domain.Hooking;
using NeatInput.Domain.Hooking.Mouse.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

using System.Collections.Generic;

namespace NeatInput.Processing.Mouse
{
    internal class InputProcessorPipeline
    {
        private readonly List<IMouseInputProcessor> _processors;

        public InputProcessorPipeline()
        {
            _processors = new List<IMouseInputProcessor>
            {
                new KeyProcessor(),
                new StateProcessor(),
                new XButtonProcessor(),
                new WheelProcessor()
            };
        }

        public MouseInput Process(
            WindowsMessages msg, 
            MSLLHOOKSTRUCT msllhookstruct)
        {
            var input = new MouseInput
            {
                X = msllhookstruct.pt.X,
                Y = msllhookstruct.pt.Y
            };

            foreach (var processor in _processors)
            {
                processor.Process(
                    ref input, 
                    msg, 
                    msllhookstruct);
            }

            return input;
        }
    }
}
