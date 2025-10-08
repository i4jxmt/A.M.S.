using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление функции y = f(x)");
        Console.Write("Введите значение x: ");

        double x = Convert.ToDouble(Console.ReadLine());

        double result = CalculateFunction(x);
        Console.WriteLine($"y = {result:F4}");
    }

    static double CalculateFunction(double x)
    {
        double N = x + (2 + Math.Cos(x)) / (x * x);
        double D = Math.Sqrt(x * x + 10);
        double y = N / D;

        return y;
    }
}