using NeatInput.Domain.Hooking;
using System;

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
            Console.WriteLine($"Key: {input.Key} | State: {input.State}");
            return;
        }
    }
}
