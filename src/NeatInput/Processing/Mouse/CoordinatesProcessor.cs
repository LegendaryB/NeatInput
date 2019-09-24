using NeatInput.Application.Processing;
using NeatInput.Domain.Native.Enums;
using NeatInput.Domain.Native.Structures;
using NeatInput.Domain.Processing.Mouse;

using System;

namespace NeatInput.Processing.Mouse
{
    public class CoordinatesProcessor : IInputProcessor<MouseInput, MSLLHOOKSTRUCT>
    {
        public void Process(
            ref MouseInput input, 
            WindowsMessages msg, 
            MSLLHOOKSTRUCT @struct)
        {
            input.X = @struct.pt.X;
            input.Y = @struct.pt.Y;
        }
    }
}
