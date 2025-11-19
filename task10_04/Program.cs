using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_4
{
    internal class Program
    {
        static bool AreDigitsDistinct(long number)
        {
            bool[] digitsSeen = new bool[10];
            while (number > 0)
            {
                int digit = (int)(number % 10);
                if (digitsSeen[digit]) return false;
                digitsSeen[digit] = true;
                number /= 10;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число с различными цифрами:");
            if (!long.TryParse(Console.ReadLine(), out long n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода. Введите натуральное число.");
                return;
            }

            if (!AreDigitsDistinct(n))
            {
                Console.WriteLine("Число содержит повторяющиеся цифры.");
                return;
            }

            int maxDigit = -1;
            int minDigit = 10;
            int maxPos = 0;
            int minPos = 0;
            int pos = 0;

            long temp = n;

            int length = 0;
            long lengthTemp = temp;
            while (lengthTemp > 0)
            {
                lengthTemp /= 10;
                length++;
            }

            while (temp > 0)
            {
                pos++;
                int digit = (int)(temp % 10);
                temp /= 10;

                int idxFromLeft = length - pos + 1;

                if (digit > maxDigit)
                {
                    maxDigit = digit;
                    maxPos = idxFromLeft;
                }
                if (digit < minDigit)
                {
                    minDigit = digit;
                    minPos = idxFromLeft;
                }
            }

            Console.WriteLine($"В числе {n} наибольшая цифра {maxDigit} стоит под номером {maxPos}, наименьшая цифра {minDigit} стоит под номером {minPos}.");
        }
    }
}
