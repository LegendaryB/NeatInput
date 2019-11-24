using NeatInput.Windows.Native.Enumerations;

namespace NeatInput.Windows.Hooking
{
    internal abstract class Hook
    {
        protected abstract HookType Type { get; }
    }
}
