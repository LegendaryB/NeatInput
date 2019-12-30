using NeatInput.Abstractions;

namespace NeatInput.Platform.Windows
{
    public class InputSource : IInputSource
    {
        public InputSource()
        {         
        }

        public void Dispose()
        {
        }

        ~InputSource() => Dispose();
    }
}
