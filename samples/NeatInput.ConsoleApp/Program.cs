using NeatInput.Windows;
using System;

namespace NeatInput.ConsoleApp
{
    class Test : IKeyboardEventReceiver<KeyboardEvent>
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputSource(new Test(), null);
            input.Listen();

            Console.ReadLine();
        }
    }
}
