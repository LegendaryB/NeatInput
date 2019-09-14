using NeatInput.Domain.Processing.Keyboard;
using NeatInput.Domain.Processing.Mouse;

using System;

namespace NeatInput.ConsoleSample
{
    class Program
    {
        private static void Main()
        {
            var inputProvider = new InputProvider();
            inputProvider.KeyboardInputReceived += OnKeyboardInputReceived;
            inputProvider.MouseInputReceived += OnMouseInputReceived;

            Console.ReadLine();
        }

        private static void OnMouseInputReceived(MouseInput input)
        {
            Console.WriteLine($"MOUSE => Key: {input.Key}, State: {input.State}, X: {input.X}, Y: {input.Y}");
        }

        private static void OnKeyboardInputReceived(KeyboardInput input)
        {
            Console.WriteLine($"KEYBOARD => Key: {input.Key}, State: {input.State}");
        }
    }
}
