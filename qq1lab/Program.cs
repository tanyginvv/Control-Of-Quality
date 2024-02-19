using System;

namespace qq1lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
                double a1;
                double a2;
                double a3;
                double a = double.TryParse(args[0], out a1) ? a1 : 0.0;
                double b = double.TryParse(args[1], out a2) ? a2 : 0.0;
                double c = double.TryParse(args[2], out a3) ? a3 : 0.0;

                try
                {
                    if ((a + b > c) && (a + c) > b && (b + c > a))
                    {
                        if ((a == b) && (b == c))
                        {
                            Console.WriteLine("Равносторонний");
                        }
                        else if ((a == c) || (a == b) || (b == c))
                        {
                            Console.WriteLine("Равнобедренный");
                        }
                        else
                        {
                            Console.WriteLine("Обычный");
                        }
                    }
                    else
                    {
                        Console.WriteLine("неизвестнаяошибка");
                    }
                }
                catch (Exception) { Console.WriteLine("неизвестнаяошибка"); }

        }
    }
}
