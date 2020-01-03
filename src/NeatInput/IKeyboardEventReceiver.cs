namespace NeatInput
{
    public interface IKeyboardEventReceiver<TKeyboardEvent> : IInputEventReceiver<TKeyboardEvent>
        where TKeyboardEvent : IInput
    {
    }
}
