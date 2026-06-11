using NUnit.Framework;
using System;

namespace RightTriangleStruct.UnitTests
{
    [TestFixture]
    public class RightTriangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var t = new RightTriangle(3.0, 4.0);
            Assert.That(t.A, Is.EqualTo(3.0).Within(1e-13));
            Assert.That(t.B, Is.EqualTo(4.0).Within(1e-13));
        }

        [TestCase(0.0)]
        [TestCase(-1.5)]
        public void ASet_NonPositiveValue_ArgumentException(double val)
        {
            var t = new RightTriangle();
            Assert.That(() => t.A = val, Throws.ArgumentException);
        }

        [TestCase(0.0)]
        [TestCase(-1.5)]
        public void BSet_NonPositiveValue_ArgumentException(double val)
        {
            var t = new RightTriangle();
            Assert.That(() => t.B = val, Throws.ArgumentException);
        }

        [TestCase(3.0,  4.0,  5.0)]
        [TestCase(5.0, 12.0, 13.0)]
        [TestCase(1.0,  1.0,  1.4142135623730951)]
        public void HypotenuseTest(double a, double b, double expected)
        {
            var t = new RightTriangle(a, b);
            Assert.That(t.Hypotenuse, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void ToStringTest()
        {
            var t = new RightTriangle(3.0, 4.0);
            var str = t.ToString();
            Assert.That(str, Does.StartWith("Прямоугольный треугольник с катетами"));
            Assert.That(str, Does.Contain("3"));
            Assert.That(str, Does.Contain("4"));
            Assert.That(str, Does.Contain("см"));
        }

        [Test]
        public void Equals_EqualTriangles_ReturnsTrue()
        {
            var t1 = new RightTriangle(3.0, 4.0);
            var t2 = new RightTriangle(3.0, 4.0);
            Assert.That(t1.Equals(t2), Is.True);
        }

        [Test]
        public void Equals_DifferentTriangles_ReturnsFalse()
        {
            var t1 = new RightTriangle(3.0, 4.0);
            var t2 = new RightTriangle(5.0, 4.0);
            Assert.That(t1.Equals(t2), Is.False);
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var t = new RightTriangle(3.0, 4.0);
            Assert.That(() => t.Equals(new object()), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var t1 = new RightTriangle(3.0, 4.0);
            var t2 = new RightTriangle(3.0, 4.0);
            var t3 = new RightTriangle(5.0, 6.0);

            Assert.That(t1.Equals(t2), Is.True);
            Assert.That(t1.GetHashCode(), Is.EqualTo(t2.GetHashCode()));
            Assert.That(t1.Equals(t3), Is.False);
        }

        [Test]
        public void ComparisonTest()
        {
            var t1 = new RightTriangle(3.0, 4.0);
            var t2 = new RightTriangle(3.0, 4.0);
            var t3 = new RightTriangle(5.0, 6.0);

            Assert.That(t1 == t2, Is.True);
            Assert.That(t1 != t2, Is.False);
            Assert.That(t1 == t3, Is.False);
            Assert.That(t1 != t3, Is.True);
        }

        [TestCase(2.0,  3.0, 4.0,  6.0,  8.0)]
        [TestCase(0.5,  6.0, 8.0,  3.0,  4.0)]
        [TestCase(3.0,  1.0, 1.0,  3.0,  3.0)]
        public void MultiplicationTest(double k, double a, double b, double resA, double resB)
        {
            var t = new RightTriangle(a, b);
            var expected = new RightTriangle(resA, resB);

            Assert.That(k * t, Is.EqualTo(expected));
            Assert.That(t * k, Is.EqualTo(expected));
        }

        [Test]
        public void Multiplication_NegativeCoefficient_ArgumentException()
        {
            var t = new RightTriangle(3.0, 4.0);
            Assert.That(() => { var _ = -1.0 * t; }, Throws.ArgumentException);
        }

        [Test]
        public void Multiplication_ZeroCoefficient_ArgumentException()
        {
            var t = new RightTriangle(3.0, 4.0);
            Assert.That(() => { var _ = 0.0 * t; }, Throws.ArgumentException);
        }
    }
}
