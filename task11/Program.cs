using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MODULE = 101;

            Console.WriteLine("Введите число элементов массива");

            var n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Слишком маленький массив.");
                return;
            }

            var numbers = new int[n];

            numbers[0] = 1;

            if (n > 1)
            {
                numbers[1] = 1;

                for (int i = 2; i < numbers.Length; i++)
                    numbers[i] = (numbers[i - 1] + numbers[i - 2]) % MODULE;
            }

            Console.WriteLine("Исходный массив:");
            PrintIntArray(numbers);

            Console.WriteLine("Введите число k для умножения элементов массива");
            var k = double.Parse(Console.ReadLine());

            var multipliedArray = MultiplyArrayByK(numbers, k);

            Console.WriteLine($"Массив элементов, умноженных на {k}:");
            PrintDoubleArray(multipliedArray);
        }

        static void PrintIntArray(int[] array)
        {
            foreach (var item in array)
                Console.Write($"{item}, ");

            Console.WriteLine("\b\b.\n");
        }

        static void PrintDoubleArray(double[] array)
        {
            foreach (var item in array)
                Console.Write($"{item:F2}, ");

            Console.WriteLine("\b\b.\n");
        }

        static double[] MultiplyArrayByK(int[] array, double k)
        {
            var result = new double[array.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = array[i] * k;

            return result;
        }
    }
}