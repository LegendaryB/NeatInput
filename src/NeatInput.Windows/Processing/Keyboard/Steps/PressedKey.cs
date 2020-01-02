using Paipurain.Application.Handler;

using System;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class PressedKey : IHandler<ProcessingValueWrapper>
    {
        public ProcessingValueWrapper Handle(ProcessingValueWrapper item)
        {
            //Console.WriteLine(item.InputStruct.vkCode);

            return item;
        }
    }
}
