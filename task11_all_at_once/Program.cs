using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int length = 20;

            // запрос входных данных
            Console.WriteLine("Введите первый член геометрической прогрессии p:");
            double p = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите знаменатель прогрессии q:");
            double q = double.Parse(Console.ReadLine());

            // шаг1 заполнение массива первыми 20 членами 
            var geometricProgression = new double[length];
            for (int i = 0; i < length; i++)
            {
                geometricProgression[i] = p * Math.Pow(q, i);
            }

            Console.WriteLine("\nИсходный массив:");
            PrintDoubleArray(geometricProgression);

            // шаг2 метод для возведения элементов массива в квадрат и вывод на консоль
            Console.WriteLine("Массив элементов, возведенных в квадрат:");
            var squared = SquareElements(geometricProgression);
            PrintDoubleArray(squared);

            // наг3 метод для вычисления среднего геометрического значения у элементов массива
            double geometricMean = GetGeometricMean(geometricProgression);
            Console.WriteLine($"Среднее геометрическое элементов массива: {geometricMean:F6}\n");

            // запрос числа k для операции умножения
            Console.WriteLine("Введите действительное число k для умножения элементов:");
            double k = double.Parse(Console.ReadLine());

            // шаг4 метод для получения массива элементов, умноженных на k
            var multiplied = MultiplyElements(geometricProgression, k);
            Console.WriteLine($"\nМассив элементов, умноженных на {k}:");
            PrintDoubleArray(multiplied);
        }

        // вывод массива действительных чисел на консоль
        static void PrintDoubleArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]:F3}");
                if (i < array.Length - 1)
                {
                    Console.Write("; ");
                }
            }
            Console.WriteLine("\n");
        }

        // метод для возведения элементов массива в квадрат
        static double[] SquareElements(double[] array)
        {
            var result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i] * array[i];
            }
            return result;
        }

        // метод для вычисления среднего геометрического элементов массива
        static double GetGeometricMean(double[] array)
        {
            if (array.Length == 0)
                return 0;

            double product = 1;
            foreach (var item in array)
            {
                if (item > 0)
                {
                    product *= item;
                }
            }

            return Math.Pow(product, 1.0 / array.Length);
        }

        // метод для умножения элементов массива на действительное число k
        static double[] MultiplyElements(double[] array, double k)
        {
            var result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i] * k;
            }
            return result;
        }
    }
}
