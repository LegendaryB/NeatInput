namespace NeatInput.Domain
{
    public abstract class Input
    {
        /// <summary>
        /// Indicates if the input was coming from the user or simulated.
        /// </summary>
        public bool? IsUserInput { get; }
    }
}
