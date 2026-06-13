using NUnit.Framework;

namespace DeliveryLibrary.UnitTests
{
    [TestFixture]
    public class OrderCompareTests
    {
        [Test]
        public void CompareToTest()
        {
            var ivanovUrgent  = new Order("T1", "A1", "Иванов", 1, "15.07.2024 14:00", OrderType.Urgent);
            var ivanovRegular = new Order("T2", "A2", "Иванов", 2, "15.07.2024 10:00", OrderType.Regular);
            var petrovRegular = new Order("T3", "A3", "Петров", 3, "15.07.2024 11:00", OrderType.Regular);
            var ivanovUrgentEarly = new Order("T4", "A4", "Иванов", 4, "15.07.2024 09:00", OrderType.Urgent);

            // Иванов < Петров (по фамилии)
            Assert.That(ivanovUrgent.CompareTo(petrovRegular), Is.LessThan(0));
            Assert.That(petrovRegular.CompareTo(ivanovUrgent), Is.GreaterThan(0));

            // Одинаковая фамилия: Срочный < Обычный
            Assert.That(ivanovUrgent.CompareTo(ivanovRegular), Is.LessThan(0));
            Assert.That(ivanovRegular.CompareTo(ivanovUrgent), Is.GreaterThan(0));

            // Одинаковая фамилия, одинаковый тип: сравнение по дате-времени
            Assert.That(ivanovUrgentEarly.CompareTo(ivanovUrgent), Is.LessThan(0));
            Assert.That(ivanovUrgent.CompareTo(ivanovUrgentEarly), Is.GreaterThan(0));

            // Сравнение с собой
            Assert.That(ivanovUrgent.CompareTo(ivanovUrgent), Is.EqualTo(0));
        }
    }
}
