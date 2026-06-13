using NUnit.Framework;
using System;

namespace DeliveryLibrary.UnitTests
{
    [TestFixture]
    public class ShipmentTests
    {
        Shipment shipment;
        Order[] allOrders;

        [SetUp]
        public void Setup()
        {
            // Подходит: Иванов, 15.07.2024
            var order1 = new Order("Ноутбук",    "NB-001", "Иванов", 1, "15.07.2024 14:00", OrderType.Urgent);
            var order2 = new Order("Мышь",       "MS-002", "Иванов", 2, "15.07.2024 10:00", OrderType.Regular);
            // Не подходит: другая фамилия
            var order3 = new Order("Клавиатура", "KB-003", "Петров", 3, "15.07.2024 11:00", OrderType.Regular);
            // Не подходит: другая дата
            var order4 = new Order("Монитор",    "MN-004", "Иванов", 4, "16.07.2024 09:00", OrderType.Regular);

            allOrders = new Order[] { order1, order2, order3, order4 };
            shipment = new Shipment("Иванов", "15.07.2024", allOrders);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(shipment.CourierSurname, Is.EqualTo("Иванов"));
            Assert.That(shipment.DeliveryDate, Is.EqualTo(new DateTime(2024, 7, 15)));
        }

        [Test]
        public void CountTest()
        {
            // В список входят только order1 и order2 (Иванов + 15.07.2024)
            Assert.That(shipment.Count, Is.EqualTo(2));
        }

        [Test]
        public void IEnumerableTest()
        {
            var expectedOrders = new Order[] { allOrders[0], allOrders[1] };
            var i = 0;
            foreach (var order in shipment)
                Assert.That(order, Is.SameAs(expectedOrders[i++]));
            Assert.That(i, Is.EqualTo(2));
        }
    }
}
