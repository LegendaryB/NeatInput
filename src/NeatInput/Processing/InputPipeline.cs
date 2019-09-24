using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing;

using System.Collections.Generic;

namespace NeatInput.Processing
{
    internal abstract class InputPipeline<TInput, TInputStruct> : IInputPipeline<TInput, TInputStruct>
        where TInput : Input, new()
        where TInputStruct : struct
    {
        protected readonly List<IInputProcessor<TInput, TInputStruct>> _pipeline =
            new List<IInputProcessor<TInput, TInputStruct>>();

        public virtual TInput Process(WindowsMessages msg, TInputStruct @struct)
        {
            var input = new TInput();

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
