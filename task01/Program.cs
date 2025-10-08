using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Автор: Александр Сергеевич Пушкин\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Название: У лукоморья дуб зелёный\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("У лукоморья дуб зелёный;");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Златая цепь на дубе том:");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("И днём и ночью кот учёный");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Всё ходит по цепи кругом;");

        Console.ResetColor();

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}