using NeatInput.Windows.Native.Window;
using System;

namespace NeatInput.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new NativeWindow(null);
            x.StartMessageLoop();

            Console.ReadLine();
        }
    }
}
