using NeatInput.Abstractions;
using System;

namespace NeatInput.ConsoleApp
{
    class Test : IInputReceiver
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputListener(new Test());
            input.Listen();

            Console.ReadLine();
        }
    }
}
