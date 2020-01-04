namespace NeatInput.Windows.Processing.Keyboard
{
    internal interface IProcessingStep
    {
        ValueWrapper Process(ValueWrapper item);
    }
}
