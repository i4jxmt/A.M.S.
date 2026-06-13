using System;

namespace RightTriangleStruct
{
    public struct RightTriangle
    {
        private const double Precision = 1e-13;

        double a;
        double b;

        public double A
        {
            get => a;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина катета должна быть положительной");
                a = value;
            }
        }

        public double B
        {
            get => b;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина катета должна быть положительной");
                b = value;
            }
        }

        // Гипотенуза вычисляется из катетов, только для чтения
        public double Hypotenuse => Math.Sqrt(a * a + b * b);

        public RightTriangle(double a, double b) : this()
        {
            A = a;
            B = b;
        }

        public override string ToString() =>
            $"Прямоугольный треугольник с катетами {A} см и {B} см";

        public override bool Equals(object obj)
        {
            if (obj is RightTriangle other)
                return Math.Abs(A - other.A) < Precision && Math.Abs(B - other.B) < Precision;
            throw new ArgumentException("Объект для сравнения не является прямоугольным треугольником");
        }

        public override int GetHashCode() => HashCode.Combine(A, B);

        public static bool operator ==(RightTriangle x, RightTriangle y) => x.Equals(y);
        public static bool operator !=(RightTriangle x, RightTriangle y) => !x.Equals(y);

        // Растяжение/сжатие: коэффициент * треугольник
        public static RightTriangle operator *(double k, RightTriangle t)
        {
            if (k <= 0)
                throw new ArgumentException("Коэффициент подобия должен быть положительным");
            return new RightTriangle(k * t.A, k * t.B);
        }

        public static RightTriangle operator *(RightTriangle t, double k) => k * t;
    }
}
