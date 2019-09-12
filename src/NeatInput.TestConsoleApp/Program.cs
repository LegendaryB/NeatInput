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
            input.InputReceived += OnInputReceived;

            Console.ReadLine();
        }

        private static void OnInputReceived(Input input)
        {
            Console.WriteLine($"X: {input.X} | Y: {input.Y}");
            return;
        }
    }
}
