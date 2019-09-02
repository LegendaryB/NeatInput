using System;

namespace NeatInput.TestConsoleApp
{
    class Program
    {
        static void Main()
        {
            var hook = InputHookManager.SetKeyboardHook();
            hook.InputReceived += Hook_InputReceived;

            Console.ReadLine();
        }

        private static void Hook_InputReceived(KeyboardInput input)
        {
            if (input.IsPressed)
                Console.WriteLine(input.Key);
        }
    }
}
