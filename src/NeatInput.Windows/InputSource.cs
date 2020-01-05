using NeatInput.Windows.Events;
using NeatInput.Windows.Hooking;

using System;
using System.Threading;

namespace NeatInput.Windows
{
    /// <summary>
    /// This is the core class which manages the mouse and keyboard hook internally and populates the results
    /// back to the user provided receivers.
    /// </summary>
    public class InputSource : IInputSource
    {
        private readonly KeyboardHook keyboardHook;
        private readonly MouseHook mouseHook;

        private readonly WeakReference<IKeyboardEventReceiver> keyboardEventReceiverRef;
        private readonly WeakReference<IMouseEventReceiver> mouseEventReceiverRef;

        /// <param name="keyboardEventReceiver">A instance of <see cref="IKeyboardEventReceiver"/> which receives keyboard events.</param>
        /// <param name="mouseEventReceiver">A instance of <see cref="IMouseEventReceiver"/> which receives mouse events.</param>
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

        /// <summary>
        /// This method sets the mouse and/or the keyboard hook into place and starts listening for input events.
        /// </summary>
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
