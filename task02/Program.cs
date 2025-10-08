using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление длины окружности и площади круга");

        Console.Write("Введите радиус:");
        double R = Convert.ToDouble(Console.ReadLine());

        double C = 2 * Math.PI * R;
        double S = Math.PI * Math.Pow(R, 2);

        Console.WriteLine($"Длина окружности: {C:F2}");
        Console.WriteLine($"Площадь круга: {S:F2}");
    }
}
