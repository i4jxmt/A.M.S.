using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class RaffaNumbers
{
    const long MOD = 10000000007;

    static bool IsPrime(long n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        long sqrt = (long)Math.Sqrt(n);
        for (long i = 3; i <= sqrt; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static List<long> GetPrimesEndingWith7(int k)
    {
        List<long> primes = new List<long>();
        long num = 7;

        while (primes.Count < k)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
            num += 10;
        }

        return primes;
    }

    static HashSet<long> CreateSet_Sk(int k)
    {
        HashSet<long> Sk = new HashSet<long> { 2, 5 };
        List<long> primes = GetPrimesEndingWith7(k);

        foreach (var prime in primes)
        {
            Sk.Add(prime);
        }

        return Sk;
    }

    static BigInteger CalculateProduct_Nk(HashSet<long> Sk)
    {
        BigInteger product = 1;
        foreach (var num in Sk)
        {
            product *= num;
        }
        return product;
    }

    static bool IsRaffaNumber(long number, HashSet<long> Sk)
    {
        foreach (var divisor in Sk)
        {
            if (number % divisor == 0)
            {
                return false; 
            }
        }
        return true; 
    }

    static long CalculateF(int k)
    {
        Console.WriteLine($"Вычисление F({k})...");

        HashSet<long> Sk = CreateSet_Sk(k);
        Console.WriteLine($"S_{k} = {{{string.Join(", ", Sk.OrderBy(x => x))}}}");

        BigInteger Nk = CalculateProduct_Nk(Sk);
        Console.WriteLine($"N_{k} = {Nk}");

        BigInteger sum = 0;
        long count = 0;

        for (long num = 7; num < (long)Nk && num > 0; num += 10)
        {
            if (IsRaffaNumber(num, Sk))
            {
                sum += num;
                count++;
            }

            if (count % 1000000 == 0 && count > 0)
            {
                Console.WriteLine($"Обработано {count} чисел Раффа...");
            }
        }

        Console.WriteLine($"Найдено {count} k-чисел Раффа");

        long result = (long)(sum % MOD);
        return result;
    }

    static void Main()
    {
        Console.WriteLine("=== Проверка примера ===");
        long f3 = CalculateF(3);
        Console.WriteLine($"F(3) = {f3}");
        Console.WriteLine($"Ожидаемое значение: 76101452");
        Console.WriteLine();

        Console.WriteLine("=== Вычисление F(k) для k от 3 до 9 ===");
        for (int k = 3; k <= 9; k++)
        {
            long result = CalculateF(k);
            Console.WriteLine($"F({k}) = {result}");
            Console.WriteLine();
        }
    }
}
