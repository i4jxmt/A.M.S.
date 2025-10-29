using System;

class Program
{
    public static void DecodePosition(string pos, out int x, out int y)
    {
        if (pos.Length != 2 || pos[0] < 'a' || pos[0] > 'h' || pos[1] < '1' || pos[1] > '8')
        {
            throw new ArgumentException("Некорректная позиция");
        }
        x = pos[0] - 'a' + 1;
        y = pos[1] - '0';     
    }
    public static bool KingThreatens(int kingX, int kingY, int targetX, int targetY)
    {
        int dx = Math.Abs(kingX - targetX);
        int dy = Math.Abs(kingY - targetY);
        return dx <= 1 && dy <= 1 && (dx != 0 || dy != 0);
    }

    public static bool RookThreatens(int rookX, int rookY, int targetX, int targetY)
    {
        return (rookX == targetX || rookY == targetY) && !(rookX == targetX && rookY == targetY);
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Шахматная проверка: Король vs Ладья");
            Console.WriteLine("Вертикали: a-h, Горизонтали: 1-8");
            Console.WriteLine();

            Console.Write("Введите позицию белой фигуры (король, например 'e1'): ");
            string whitePos = Console.ReadLine().ToLower();

            Console.Write("Введите позицию чёрной фигуры (ладья, например 'a8'): ");
            string blackPos = Console.ReadLine().ToLower();

            if (whitePos == blackPos)
            {
                Console.WriteLine("Ошибка: позиции фигур совпадают!");
                return;
            }

            DecodePosition(whitePos, out int wkX, out int wkY);
            DecodePosition(blackPos, out int brX, out int brY);

            bool kingThreatensRook = KingThreatens(wkX, wkY, brX, brY);
            bool rookThreatensKing = RookThreatens(brX, brY, wkX, wkY);

            Console.WriteLine();
            Console.WriteLine($"Позиция короля: {whitePos} ({wkX},{wkY})");
            Console.WriteLine($"Позиция ладьи: {blackPos} ({brX},{brY})");
            Console.WriteLine();

            if (kingThreatensRook)
                Console.WriteLine("Король бьёт ладью.");
            if (rookThreatensKing)
                Console.WriteLine("Ладья бьёт короля.");
            if (!kingThreatensRook && !rookThreatensKing)
                Console.WriteLine("Фигуры не бьют друг друга.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}