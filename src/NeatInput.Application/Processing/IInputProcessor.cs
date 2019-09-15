using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Processing;

namespace NeatInput.Application.Processing
{
    public interface IInputProcessor<TInput, TInputStruct>
        where TInput : Input
        where TInputStruct : struct
    {
        void Process(
            ref TInput input,
            WindowsMessages msg,
            TInputStruct @struct);
    }
}
