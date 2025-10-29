using System;

namespace Transliteration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на русском языке");
            var text = Console.ReadLine();

            Console.WriteLine("Вот что получилось:");
            Console.WriteLine(Transliterate(text));
        }

        static string Transliterate(string s)
        {
            var result = s
                .Replace("А", "A").Replace("а", "a")
                .Replace("Б", "B").Replace("б", "b")
                .Replace("В", "V").Replace("в", "v")
                .Replace("Г", "G").Replace("г", "g")
                .Replace("Д", "D").Replace("д", "d")
                .Replace("Е", "E").Replace("е", "e")
                .Replace("Ё", "E").Replace("ё", "e")
                .Replace("Ж", "ZH").Replace("ж", "zh")
                .Replace("З", "Z").Replace("з", "z")
                .Replace("И", "I").Replace("и", "i")
                .Replace("Й", "I").Replace("й", "i")
                .Replace("К", "K").Replace("к", "k")
                .Replace("Л", "L").Replace("л", "l")
                .Replace("М", "M").Replace("м", "m")
                .Replace("Н", "N").Replace("н", "n")
                .Replace("О", "O").Replace("о", "o")
                .Replace("П", "P").Replace("п", "p")
                .Replace("Р", "R").Replace("р", "r")
                .Replace("С", "S").Replace("с", "s")
                .Replace("Т", "T").Replace("т", "t")
                .Replace("У", "U").Replace("у", "u")
                .Replace("Ф", "F").Replace("ф", "f")
                .Replace("Х", "KH").Replace("х", "kh")
                .Replace("Ц", "TS").Replace("ц", "ts")
                .Replace("Ч", "CH").Replace("ч", "ch")
                .Replace("Ш", "SH").Replace("ш", "sh")
                .Replace("Щ", "SHCH").Replace("щ", "shch")
                .Replace("Ъ", "").Replace("ъ", "")
                .Replace("Ы", "Y").Replace("ы", "y")
                .Replace("Ь", "IE").Replace("ь", "ie")
                .Replace("Э", "E").Replace("э", "e")
                .Replace("Ю", "IU").Replace("ю", "iu")
                .Replace("Я", "IA").Replace("я", "ia");

            return result;
        }
    }
}