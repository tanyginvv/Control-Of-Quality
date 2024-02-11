using System;

namespace qq1lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(args[0]);
            int b = int.Parse(args[1]);
            int c = int.Parse(args[2]);

            if(( a + b > c ) && ( a + c ) > b  && ( b + c > a))
            {
                if ( (a == b) && (b == c))
                {
                    Console.WriteLine("Равносторонний");
                }
                else if( (a == c) || ( a == b ) || ( b == c ) )  
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
                Console.WriteLine("Ошибка");
            }

        }
    }
}
