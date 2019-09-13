using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;

namespace NeatInput.Domain.Hooking.Mouse.Processing
{
    public interface IMouseInputProcessor
    {
        void Process(
            ref MouseInput input,
            WindowsMessages windowsMessage, 
            MSLLHOOKSTRUCT hookStruct);
    }
}
