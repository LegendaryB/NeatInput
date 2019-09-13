using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;

namespace NeatInput.Application.Processing.Mouse
{
    public interface IMouseInputProcessor
    {
        void Process(
            ref MouseInput input,
            WindowsMessages windowsMessage, 
            MSLLHOOKSTRUCT hookStruct);
    }
}
