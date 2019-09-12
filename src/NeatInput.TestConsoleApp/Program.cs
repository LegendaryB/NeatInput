using NeatInput.Domain.Hooking;
using System;
using System.Threading;

namespace NeatInput.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputProvider();
            input.KeyboardInputReceived += Input_KeyboardInputReceived;

            Console.ReadLine();
        }

        private static void Input_KeyboardInputReceived(Input input)
        {
            Console.WriteLine(input.Key);
            return;
        }
    }
}
