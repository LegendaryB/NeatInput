using NeatInput.Domain.Hooking.Enums;
using NeatInput.Domain.Native.Enums;

namespace NeatInput.Domain.Hooking
{
    public class MouseInput : Input
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Helper method to set the key and state to undefined.
        /// </summary>
        public MouseInput AsUndefined()
        {
            Key = VirtualKeyCodes.Undefined;
            State = KeyState.Undefined;

            return this;
        }
    }
}
