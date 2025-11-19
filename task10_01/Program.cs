using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два натуральных числа n и k (через пробел):");
            string input = Console.ReadLine();
            string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2 || !int.TryParse(parts[0], out int n) || !int.TryParse(parts[1], out int k) || n <= 0 || k <= 0)
            {
                Console.WriteLine("Ошибка ввода. Введите два натуральных числа.");
                return;
            }

            double sum = 1.0;

            for (int i = n; i <= k; i++)
            {
                sum += 1.0 / Math.Pow(i, 2);
            }

            Console.WriteLine($"Сумма равна {sum}");
        }
    }
}
