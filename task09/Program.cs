using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение аргумента");

            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x:F2}) = {F(x):F2}");
        }

        static double F(double x)
        {
            if (x <= 0)
                return 0;
            else if (x > 0 && x <= 1)
                return x;
            else // if (x > 1)
                return x * x;
        }
    }
}