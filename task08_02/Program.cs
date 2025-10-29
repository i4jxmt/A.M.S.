using System;

class Program
{
    public static bool IsInArea(double x, double y)
    {
        return (x >= -1 && x <= 1.5) && (y >= -0.5 && y <= 2);
    }

    static void Main()
    {
        Console.WriteLine("Проверка принадлежности точки области");
        Console.WriteLine("Область: прямоугольник [-1 ≤ x ≤ 1,5] и [-0,5 ≤ y ≤ 2]");
        Console.WriteLine();

        try
        {
            Console.Write("Введите координату x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите координату y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            bool result = IsInArea(x, y);

            Console.WriteLine();
            Console.WriteLine($"Точка ({x}, {y}) {(result ? "ПРИНАДЛЕЖИТ" : "НЕ ПРИНАДЛЕЖИТ")} заданной области");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите числовые значения координат!");
        }
    }
}