namespace NeatInput.Windows.Events
{
    public abstract class InputEvent
    {
        /// <summary>
        /// Flag which indicates if the input was simulated or not.
        /// </summary>
        public bool HasBeenSimulated { get; internal set; }
    }
}
