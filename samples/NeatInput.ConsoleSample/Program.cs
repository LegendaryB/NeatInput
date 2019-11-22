using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Mouse;
using NeatInput.Windows.Native.Window;
using System;

namespace NeatInput.ConsoleSample
{
    class Program
    {
        private static void Main()
        {
            var x = new NativeWindow(WndProc);
            x.StartMessageLoop();

            //var inputProvider = new InputProvider();
            //inputProvider.KeyboardInputReceived += OnKeyboardInputReceived;
            //inputProvider.MouseInputReceived += OnMouseInputReceived;

            Console.ReadLine();
        }

        // todo wrap
        public static void WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {

        }

        private static void OnMouseInputReceived(MouseInput input)
        {
            Console.WriteLine($"MOUSE => Key: {input.Key}, State: {input.State}, X: {input.X}, Y: {input.Y}, Simulated: {input.WasSimulated}");
        }

        private static void OnKeyboardInputReceived(KeyboardInput input)
        {
            Console.WriteLine($"KEYBOARD => Key: {input.Key}, State: {input.State}, Simulated: {input.WasSimulated}");
        }
    }
}
