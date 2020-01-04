using NeatInput.Windows.Events;
using NeatInput.Windows.Hooking;

using System;
using System.Threading;

namespace NeatInput.Windows
{
    public class InputSource : IDisposable
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        private readonly WeakReference<IKeyboardEventReceiver> keyboardEventReceiverRef;
        private readonly WeakReference<IMouseEventReceiver> mouseEventReceiverRef;

        public InputSource(
            IKeyboardEventReceiver keyboardEventReceiver = null, 
            IMouseEventReceiver mouseEventReceiver = null)
        {
            if (keyboardEventReceiver == null && mouseEventReceiver == null)
                throw new InvalidOperationException();
            
            if (keyboardEventReceiver != null)
            {
                keyboardEventReceiverRef = new WeakReference<IKeyboardEventReceiver>(keyboardEventReceiver);
                keyboardHook = new KeyboardHook();
                keyboardHook.RawInputProcessed += OnRawKeyboardInputProcessed;
            }

            if (mouseEventReceiver != null)
            {
                mouseEventReceiverRef = new WeakReference<IMouseEventReceiver>(mouseEventReceiver);
                mouseHook = new MouseHook();
                mouseHook.RawInputProcessed += OnRawMouseInputProcessed;
            }
        }

        public void Listen()
        {
            ExecuteInNewThread(keyboardHook);
            ExecuteInNewThread(mouseHook);
        }

        private void OnRawKeyboardInputProcessed(KeyboardEvent @event)
        {
            if (!keyboardEventReceiverRef.TryGetTarget(out var receiver))
                return;

            receiver.Receive(@event);
        }

        private void OnRawMouseInputProcessed(MouseEvent @event)
        {
            if (!mouseEventReceiverRef.TryGetTarget(out var receiver))
                return;

            receiver.Receive(@event);
        }

        private void ExecuteInNewThread<THook>(THook hook)
            where THook :Hook
        {
            if (hook == null)
                return;

            var thread = new Thread(() => hook.SetHook())
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };

            thread.Start();
        }

        public void Dispose()
        {
            keyboardHook.RawInputProcessed -= OnRawKeyboardInputProcessed;
            mouseHook.RawInputProcessed -= OnRawMouseInputProcessed;

            keyboardHook?.Dispose();
            mouseHook?.Dispose();
        }

        ~InputSource() => Dispose();
    }
}
