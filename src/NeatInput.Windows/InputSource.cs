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
        private readonly KeyboardHook _keyboardHook;
        private readonly MouseHook _mouseHook;

        private readonly WeakReference<IKeyboardEventReceiver> _keyboardEventReceiver;
        private readonly WeakReference<IMouseEventReceiver> _mouseEventReceiver;

        /// <summary>
        /// Controls if the affected hook is unset when the correspondending receiver died.
        /// </summary>
        public bool UnsetHookOnReceiverDead { get; set; }

        /// <param name="keyboardEventReceiver">A instance of <see cref="IKeyboardEventReceiver"/> which receives keyboard events.</param>
        /// <param name="mouseEventReceiver">A instance of <see cref="IMouseEventReceiver"/> which receives mouse events.</param>
        public InputSource(
            IKeyboardEventReceiver keyboardEventReceiver, 
            IMouseEventReceiver mouseEventReceiver)
        {
            if (keyboardEventReceiver == null)
            {
                throw new ArgumentNullException(nameof(keyboardEventReceiver));
            }

            if (mouseEventReceiver == null)
            {
                throw new ArgumentNullException(nameof(mouseEventReceiver));
            }

            _keyboardEventReceiver = new WeakReference<IKeyboardEventReceiver>(
                keyboardEventReceiver);

            _mouseEventReceiver = new WeakReference<IMouseEventReceiver>(
                mouseEventReceiver);

            _keyboardHook = SetKeyboardHook();
            _mouseHook = SetMouseHook();
        }

        /// <param name="eventReceiver">A instance of <see cref="IKeyboardEventReceiver"/> which receives keyboard events.</param>
        public InputSource(IKeyboardEventReceiver eventReceiver)
        {
            if (eventReceiver == null)
            {
                throw new ArgumentNullException(nameof(eventReceiver));
            }

            _keyboardEventReceiver = new WeakReference<IKeyboardEventReceiver>(
                eventReceiver);

            _keyboardHook = SetKeyboardHook();
        }

        /// <param name="eventReceiver">A instance of <see cref="IMouseEventReceiver"/> which receives mouse events.</param>
        public InputSource(IMouseEventReceiver eventReceiver)
        {
            if (eventReceiver == null)
            {
                throw new ArgumentNullException(nameof(eventReceiver));
            }

            _mouseEventReceiver = new WeakReference<IMouseEventReceiver>(
                eventReceiver);

            _mouseHook = SetMouseHook();
        }

        /// <summary>
        /// This method sets the mouse and/or the keyboard hook into place and starts listening for input events.
        /// </summary>
        public void Listen()
        {
            var thread = new Thread(() =>
            {
                _keyboardHook?.SetHook();
                _mouseHook?.SetHook();

                ThreadContext.MessageLoop();
            });

            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OnRawKeyboardInputProcessed(KeyboardEvent @event)
        {
            if (!_keyboardEventReceiver.TryGetTarget(out var receiver) && UnsetHookOnReceiverDead)
            {
                UnsetKeyboardHook();
                return;
            }

            receiver.Receive(@event);
        }

        private void OnRawMouseInputProcessed(MouseEvent @event)
        {
            if (!_mouseEventReceiver.TryGetTarget(out var receiver) && UnsetHookOnReceiverDead)
            {
                UnsetMouseHook();
                return;
            }

            receiver.Receive(@event);
        }

        private KeyboardHook SetKeyboardHook()
        {
            var khook = new KeyboardHook();
            khook.RawInputProcessed += OnRawKeyboardInputProcessed;

            return khook;
        }

        private MouseHook SetMouseHook()
        {
            var mhook = new MouseHook();
            mhook.RawInputProcessed += OnRawMouseInputProcessed;

            return mhook;
        }

        private void UnsetKeyboardHook()
        {
            if (_keyboardHook == null)
            {
                return;
            }

            _keyboardHook.RawInputProcessed -= OnRawKeyboardInputProcessed;
            _keyboardHook?.Dispose();
        }

        private void UnsetMouseHook()
        {
            if (_mouseHook == null)
            {
                return;
            }

            _mouseHook.RawInputProcessed -= OnRawMouseInputProcessed;
            _mouseHook.Dispose();
        }

        public void Dispose()
        {
            UnsetKeyboardHook();
            UnsetMouseHook();

            ThreadContext.Stop();
        }

        ~InputSource() => Dispose();
    }
}
