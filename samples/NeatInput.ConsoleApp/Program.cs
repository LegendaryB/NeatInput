using NeatInput.Windows;
using System;

namespace NeatInput.ConsoleApp
{
    class Test : IKeyboardEventReceiver
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputSource(new Test(), null);
            input.Capture();

            Console.ReadLine();
        }
    }
}
