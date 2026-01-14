using System;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0, n = 0;

            while (true)
            {
                Console.WriteLine("Введите через пробел два натуральных числа m и n от 5 до 20");
                Console.WriteLine("(Enter - отказ от ввода)");
                var input = Console.ReadLine();

                if (input == string.Empty)
                    return;

                var strings = input.Split();

                if (strings.Length == 2 &&
                    int.TryParse(strings[0], out m) &&
                    int.TryParse(strings[1], out n) &&
                    5 <= m && m <= 20 &&
                    5 <= n && n <= 20)
                    break;
                else
                    Console.WriteLine("Ошибка ввода");
            }

            var matrix = new int[m, n];
            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(0, 100);

            Console.WriteLine();
            PrintTable(matrix);
            Console.WriteLine();

            int k;

            while (true)
            {
                Console.Write("Введите цифру от 0 до 9: ");
                var s = Console.ReadLine();

                if (int.TryParse(s, out k) && 0 <= k && k <= 9)
                    break;
                else
                    Console.WriteLine("Ошибка ввода цифры");
            }

            int rowIndex, columnIndex;
            bool isFound = FindNumberEndingWithDigit(matrix, k, out rowIndex, out columnIndex);

            if (isFound)
                Console.WriteLine($"Найден элемент, оканчивающийся на {k}: индексы строки = {rowIndex}, столбца = {columnIndex}");
            else
                Console.WriteLine($"В массиве нет числа, оканчивающегося на {k}");

            Console.WriteLine();

            var mins = GetRowMinElements(matrix);

            for (int i = 0; i < mins.Length; i++)
            {
                Console.WriteLine($"Строка {i}: минимальный элемент = {mins[i].Value}, индекс столбца = {mins[i].ColumnIndex}");
            }
        }

        static void PrintTable(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                    Console.Write($"{table[i, j],3} ");
                Console.WriteLine();
            }
        }

        static bool FindNumberEndingWithDigit(int[,] table, int digit,
                                              out int rowIndex, out int columnIndex)
        {
            rowIndex = -1;
            columnIndex = -1;

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    int lastDigit = table[i, j] % 10;
                    if (lastDigit == digit)
                    {
                        rowIndex = i;
                        columnIndex = j;
                        return true;
                    }
                }
            }

            return false;
        }

        struct RowMinInfo
        {
            public int Value;
            public int ColumnIndex;
        }

        static RowMinInfo[] GetRowMinElements(int[,] table)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);

            var result = new RowMinInfo[rows];

            for (int i = 0; i < rows; i++)
            {
                int minValue = int.MaxValue;
                int minColumnIndex = -1;

                for (int j = 0; j < columns; j++)
                {
                    if (table[i, j] < minValue)
                    {
                        minValue = table[i, j];
                        minColumnIndex = j;
                    }
                }

                result[i] = new RowMinInfo { Value = minValue, ColumnIndex = minColumnIndex };
            }

            return result;
        }
    }
}
