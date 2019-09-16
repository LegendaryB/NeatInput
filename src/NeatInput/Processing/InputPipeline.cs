using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing;

using System.Collections.Generic;

namespace NeatInput.Processing
{
    internal abstract class InputPipeline<TInput, TInputStruct> : IInputPipeline<TInput, TInputStruct>
        where TInput : Input
        where TInputStruct : struct
    {
        protected readonly List<IInputProcessor<TInput, TInputStruct>> _pipeline =
            new List<IInputProcessor<TInput, TInputStruct>>();

        public abstract TInput Process(
            WindowsMessages msg, 
            TInputStruct @struct);
    }
}
