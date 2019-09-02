using System;

namespace NeatInput.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHookManager.SetKeyboardHook(out var hook);

            Console.WriteLine("Hello World!");
        }
    }
}
