using NeatInput.Windows;
using NeatInput.Windows.Events;

using System;

namespace NeatInput.ConsoleApp
{
    class Test : IKeyboardEventReceiver
    {
        public void Receive(KeyboardEvent @event)
        {
            Console.WriteLine(@event.Key + " | " + @event.State);
        }
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
