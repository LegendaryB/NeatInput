using NeatInput.Windows;
using NeatInput.Windows.Events;

using System;
using System.Threading.Tasks;

namespace NeatInput.ConsoleApp
{
    class Test : IKeyboardEventReceiver
    {
        public Task HandleEvent(KeyboardEvent @event)
        {
            Console.WriteLine(@event.Key + " | " + @event.State);
            return Task.CompletedTask;
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
