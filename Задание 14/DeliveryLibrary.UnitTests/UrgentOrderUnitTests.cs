using NUnit.Framework;

namespace DeliveryLibrary.UnitTests
{
    [TestFixture]
    public class UrgentOrderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var order = CreateTestUrgentOrder();

            Assert.That(order.UrgencySurchargeRate, Is.EqualTo(1.5).Within(1e-10));
            Assert.That(order.UrgencyLevel, Is.EqualTo(UrgencyLevel.WithinThreeHours));
        }

        [Test]
        public void GetInfo_UrgentOrder_ThreeStringInfo()
        {
            var order = CreateTestUrgentOrder();
            var info = order.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Заявка №1: Ноутбук"));
            Assert.That(info[1], Is.EqualTo(
                "Артикул: NB-001. Курьер: Иванов. Доставка: 15.07.2024 14:00. Тип: срочный."));
            Assert.That(info[2], Does.Contain("Срочный заказ"));
            Assert.That(info[2], Does.Contain("в течение трех часов"));
        }

        private UrgentOrder CreateTestUrgentOrder()
        {
            return new UrgentOrder("Ноутбук", "NB-001", "Иванов", 1, "15.07.2024 14:00",
                                   1.5, UrgencyLevel.WithinThreeHours);
        }
    }
}
