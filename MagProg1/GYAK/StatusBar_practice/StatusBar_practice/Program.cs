using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatusBar_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int currentCursorPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    //Need to consume the keypress with ReadKey to clear the KeyAvailable value!
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    //if (cki.Key == ConsoleKey.Spacebar)
                    //{
                    Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("     ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(currentCursorPosition + 6, 0);
                        currentCursorPosition += 6;
                    //}
                    Thread.Sleep(10);
                }
            }
        }
    }
}
