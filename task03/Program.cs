using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Реверс трехзначного числа");
        Console.Write("Введите трехзначное число: ");

        int number = Convert.ToInt32(Console.ReadLine());

        if (number < 100 || number > 999)
        {
            Console.WriteLine("Ошибка: введено не трехзначное число!");
            return;
        }

        int n1 = number / 100;
        int n2 = (number / 10) % 10;
        int n3 = number % 10;

        int X = n3 * 100 + n2 * 10 + n1;

        Console.WriteLine($"Исходное число: {number}");
        Console.WriteLine($"Обратное число: {X}");
    }
}