using System;

class Program
{
    public static bool IsMultipleOf2Or3(int n)
    {
        return n % 2 == 0 || n % 3 == 0;
    }

    static void Main()
    {
        Console.Write("Введите число n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        bool result = IsMultipleOf2Or3(n);

        Console.WriteLine($"Число {n} кратно 2 или 3: {result}");
    }
}