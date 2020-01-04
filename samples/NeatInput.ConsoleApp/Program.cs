using NeatInput.Windows;
using NeatInput.Windows.Events;

using System;

namespace NeatInput.ConsoleApp
{
    class Test : IKeyboardEventReceiver, IMouseEventReceiver
    {
        public void Receive(KeyboardEvent @event)
        {
            Console.WriteLine(@event.Key + " | " + @event.State);
        }

        public void Receive(MouseEvent @event)
        {
            Console.WriteLine(@event.Key);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();

            var input = new InputSource(test, test);
            input.Listen();

            Console.ReadLine();
        }
    }
}
