using System.Threading.Tasks;

namespace NeatInput.Windows
{
    public interface IInputEventReceiver<TInputEvent>
        where TInputEvent : class
    {
        Task HandleEvent(TInputEvent @event);    
    }
}
