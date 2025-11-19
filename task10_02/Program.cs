using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел n:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода. Введите натуральное число n.");
                return;
            }

            double result = 0;
            bool sign = false;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Введите {i}-е число:");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Ошибка ввода.");
                    return;
                }

                if (i % 2 == 1)
                {
                    result += a;
                }
                else
                {
                    result -= a;
                }
            }

            if (n % 2 == 0)
            {
                result += (-1) * 0;
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}
