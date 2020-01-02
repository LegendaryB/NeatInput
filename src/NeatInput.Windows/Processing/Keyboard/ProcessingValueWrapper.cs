using NeatInput.Windows.Win32.Enums;
using NeatInput.Windows.Win32.Structs;

namespace NeatInput.Windows.Processing.Keyboard
{
    internal class ProcessingValueWrapper
    {
        internal WindowsMessages Message { get; set; }
        internal KBDLLHOOKSTRUCT InputStruct { get; set; }
    }
}
