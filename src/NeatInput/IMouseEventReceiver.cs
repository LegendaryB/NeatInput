namespace NeatInput
{
    public interface IMouseEventReceiver<TMouseEvent> : IInputEventReceiver<TMouseEvent>
        where TMouseEvent : IInput
    {
    }
}
