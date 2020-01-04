namespace NeatInput.Windows
{
    public interface IInputEventReceiver<TInputEvent>
        where TInputEvent : class
    {
        void Receive(TInputEvent @event);    
    }
}
