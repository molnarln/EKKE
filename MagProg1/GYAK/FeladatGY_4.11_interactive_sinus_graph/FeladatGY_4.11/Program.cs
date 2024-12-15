using System;
using System.Threading;

namespace FeladatGY_4._11_sajat
{
    internal class Program
    {
        static double a = 10, b = 1, c = 0, d = 0;
        static int resolution = 1;
        static ConsoleKey CurrentSelected;
        static double step = 0.5;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();

                DrawCoordinateSystem();
                DrawFunction();
                CheckKeyPress();

                Thread.Sleep(10);

            }
        }

        static void DrawFunction()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                int value = CalculateSin((i - Console.WindowWidth / 2) * 0.1);

                // Set the borders of the coordinate-system:
                if ((i > 0
                    && i <= Console.WindowWidth
                    && value + (Console.WindowHeight + 1) / 2 > 0
                    && Math.Abs(value + Console.WindowHeight / 2) <= Console.WindowHeight)
                    && i % resolution == 0
                    )
                {

                    Console.SetCursorPosition(i, Console.WindowHeight - (value + Console.WindowHeight / 2));
                    Console.Write('*');
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(false).Key;

                if (key == ConsoleKey.A || key == ConsoleKey.B || key == ConsoleKey.C || key == ConsoleKey.D || key == ConsoleKey.R)
                {
                    CurrentSelected = key;
                }
                else
                {
                    SetParameters(key);
                }

            }
        }

        static void SetParameters(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                switch (CurrentSelected)
                {
                    case ConsoleKey.A:
                        a += step;
                        break;
                    case ConsoleKey.B:
                        b += step;
                        break;
                    case ConsoleKey.C:
                        c += step;
                        break;
                    case ConsoleKey.D:
                        d += step;
                        break;
                    case ConsoleKey.R:
                        if (resolution < 3)
                        {
                            resolution++;
                        }
                        else
                        {
                            resolution = 1;
                        }
                        break;
                }
            }
            if (key == ConsoleKey.DownArrow)
            {
                switch (CurrentSelected)
                {
                    case ConsoleKey.A:
                        a -= step;
                        break;
                    case ConsoleKey.B:
                        b -= step;
                        break;
                    case ConsoleKey.C:
                        c -= step;
                        break;
                    case ConsoleKey.D:
                        d -= step;
                        break;
                    case ConsoleKey.R:
                        if (resolution > 1)
                        {
                            resolution--;
                        }
                        else
                        {
                            resolution = 3;
                        }
                        break;
                }
            }
        }

        static int CalculateSin(double x)
        {
            //return Convert.ToInt32(a * (Math.Sin(b * x + c) / Math.Cos(b * x + c)) + d);
            return Convert.ToInt32(a * Math.Cos(b * x + c) + d);
        }

        static void DrawCoordinateSystem()
        {
            //for (int row = 0; row < Console.WindowWidth; row++)
            //{
            //    for (int column= 0; column < Console.WindowHeight; column++)
            //    {
            //        Console.SetCursorPosition(row, column);
            //        if (row == Console.WindowWidth/2)
            //        {
            //            Console.Write("|");
            //        }
            //        if(column == Console.WindowHeight / 2)
            //        {
            //            Console.Write(("-"));
            //        }
            //    }
            //}

            //Faster: 

            Console.SetCursorPosition(0, Console.WindowHeight / 2);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.Write('|');

            }
        }
    }
}
