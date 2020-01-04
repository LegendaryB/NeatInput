namespace NeatInput.Windows.Events
{
    public abstract class InputEvent
    {
        public bool HasBeenSimulated { get; internal set; }
    }
}
