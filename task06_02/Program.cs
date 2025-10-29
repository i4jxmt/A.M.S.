using System;

namespace task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "вертикаль";

            string first_word = word.Substring(4, 2) +
                          word.Substring(2, 1);

            string second_word = word.Substring(0, 1) +
                          word.Substring(2, 2) +
                          word.Substring(5, 2);

            Console.WriteLine("Первое слово: " + first_word);
            Console.WriteLine("Второе слово: " + second_word);
        }
    }
}
