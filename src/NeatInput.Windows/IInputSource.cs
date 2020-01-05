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
        /// This method installs the mouse and/or the keyboard hook and starts listening for input events.
        /// </summary>
        void Listen();
    }
}
