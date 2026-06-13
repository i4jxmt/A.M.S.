using NUnit.Framework;
using System;

namespace DeliveryLibrary.UnitTests
{
    [TestFixture]
    public class OrderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var order = CreateTestOrder();

            Assert.That(order.ProductName, Is.EqualTo("Ноутбук"));
            Assert.That(order.ArticleNumber, Is.EqualTo("NB-001"));
            Assert.That(order.CourierSurname, Is.EqualTo("Иванов"));
            Assert.That(order.OrderNumber, Is.EqualTo(1));
            Assert.That(order.DeliveryDateTime.ToString("dd.MM.yyyy HH:mm"),
                        Is.EqualTo("15.07.2024 14:00"));
            Assert.That(order.OrderType, Is.EqualTo(OrderType.Urgent));
        }

        [Test]
        public void GetInfoTest()
        {
            var order = CreateTestOrder();
            var info = order.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Заявка №1: Ноутбук"));
            Assert.That(info[1], Is.EqualTo(
                "Артикул: NB-001. Курьер: Иванов. Доставка: 15.07.2024 14:00. Тип: срочный."));
        }

        [Test]
        public void ConstructorThrowsOnInvalidDate()
        {
            Assert.Throws<ArgumentException>(() =>
                new Order("Товар", "ART-1", "Петров", 2, "не_дата", OrderType.Regular));
        }

        private Order CreateTestOrder()
        {
            return new Order("Ноутбук", "NB-001", "Иванов", 1, "15.07.2024 14:00", OrderType.Urgent);
        }
    }
}
