using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность целых чисел, оканчивающуюся нулём:");

            int sum = 0;
            int count = 0;

            while (true)
            {
                int value = int.Parse(Console.ReadLine());
                if (value == 0)
                    break;

                sum += value;
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine("Нет ни одного числа, кроме завершающего нуля.");
                return;
            }

            double average = (double)sum / count;
            Console.WriteLine($"Среднее арифметическое: {average}");
        }
    }
}
