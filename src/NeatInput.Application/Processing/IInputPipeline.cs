using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing;

namespace NeatInput.Application.Processing
{
    public interface IInputPipeline<TInput, TInputStruct>
        where TInput : Input
        where TInputStruct : struct
    {
        TInput Process(WindowsMessages msg, TInputStruct @struct);
    }
}
