using NeatInput.Application;
using NeatInput.Windows.Native.Window;

namespace NeatInput.Windows
{
    public class InputSource : IInputSource
    {
        private readonly NativeWindow _window;

        public InputSource()
        {

        }

        public void Dispose()
        {
            _window.Dispose();
        }
    }
}
