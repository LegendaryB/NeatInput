using System;

namespace NeatInput.Windows
{
    /// <summary>
    /// This is the interface for the <see cref="InputSource"/> class which manages the mouse and keyboard hook internally and populates the results
    /// back to the user provided receivers.
    /// </summary>
    public interface IInputSource : IDisposable
    {
        /// <summary>
        /// Controls if the affected hook is unset when the correspondending receiver died.
        /// </summary>
        bool UnsetHookOnReceiverDead { get; set; }

        /// <summary>
        /// This method sets the mouse and/or the keyboard hook into place and starts listening for input events.
        /// </summary>
        void Listen();
    }
}
