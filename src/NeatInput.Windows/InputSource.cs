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

        /// <summary>
        /// Controls if the affected hook is unset when the correspondending receiver died.
        /// </summary>
        public bool UnsetHookOnReceiverDead { get; set; }

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
            var thread = new Thread(() =>
            {
                keyboardHook.SetHook();
                mouseHook.SetHook();

                MessageLoop.Run();
            });

            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OnRawKeyboardInputProcessed(KeyboardEvent @event)
        {
            if (!keyboardEventReceiverRef.TryGetTarget(out var receiver) && UnsetHookOnReceiverDead)
            {
                UnsetKeyboardHook();
                return;
            }

            receiver.Receive(@event);
        }

        private void OnRawMouseInputProcessed(MouseEvent @event)
        {
            if (!mouseEventReceiverRef.TryGetTarget(out var receiver) && UnsetHookOnReceiverDead)
            {
                UnsetMouseHook();
                return;
            }

            receiver.Receive(@event);
        }

        private void UnsetKeyboardHook()
        {
            if (keyboardHook == null)
                return;

            keyboardHook.RawInputProcessed -= OnRawKeyboardInputProcessed;
            keyboardHook?.Dispose();
        }

        private void UnsetMouseHook()
        {
            if (mouseHook == null)
                return;

            mouseHook.RawInputProcessed -= OnRawMouseInputProcessed;
            mouseHook.Dispose();
        }

        public void Dispose()
        {
            UnsetKeyboardHook();
            UnsetMouseHook();

            MessageLoop.Stop();
        }

        ~InputSource() => Dispose();
    }
}
