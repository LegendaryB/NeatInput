using NeatInput.Windows.Processing.Keyboard.Enums;

namespace NeatInput.Windows.Processing.Keyboard.Steps
{
    internal class PressedKey : IProcessingStep
    {
        public ValueWrapper Process(ValueWrapper item)
        {
            item.Output.Key = (KeyCodes)item.InputStruct.vkCode;

            return item;
        }
    }
}
