using NeatInput.Platform.Windows.Win32.Enums;
using NeatInput.Platform.Windows.Win32.Structs;

namespace NeatInput.Platform.Windows.Processing.Keyboard
{
    internal class ProcessingValueWrapper
    {
        internal WindowsMessages Message { get; set; }
        internal KBDLLHOOKSTRUCT InputStruct { get; set; }
    }
}
