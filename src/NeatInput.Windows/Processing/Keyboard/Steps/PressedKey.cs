using NeatInput.Windows.Processing.Keyboard.Enums;

using Paipurain.Application.Handler;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class PressedKey : IHandler<ValueWrapper>
    {
        public ValueWrapper Handle(ValueWrapper item)
        {
            item.Output.Key = (KeyCodes)item.InputStruct.vkCode;

            return item;
        }
    }
}
