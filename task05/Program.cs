using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("вычисление значения x");

        double fraction1 = CalculateFraction(5, 7);
        double fraction2 = CalculateFraction(12, 8);
        double fraction3 = CalculateFraction(31, 2);

        double x = fraction1 * fraction2 * fraction3;
        Console.WriteLine($"x = {x:F3}");
    }

    static double CalculateFraction(int a, int b)
    {
        double N = a + Math.Sqrt(a);
        double D = b + Math.Sqrt(b);
        return N / D;
    }
}