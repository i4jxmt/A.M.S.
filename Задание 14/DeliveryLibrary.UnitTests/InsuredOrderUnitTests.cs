using NUnit.Framework;

namespace DeliveryLibrary.UnitTests
{
    [TestFixture]
    public class InsuredOrderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var order = CreateTestInsuredOrder();

            Assert.That(order.InsuranceCompanyName, Is.EqualTo("СберСтрах"));
            Assert.That(order.InsuranceAmount, Is.EqualTo(50000.0).Within(1e-10));
        }

        [Test]
        public void GetInfo_InsuredOrder_ThreeStringInfo()
        {
            var order = CreateTestInsuredOrder();
            var info = order.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Заявка №2: Планшет"));
            Assert.That(info[1], Does.Contain("Артикул: TB-002"));
            Assert.That(info[2], Does.Contain("СберСтрах"));
            Assert.That(info[2], Does.Contain("50000"));
        }

        private InsuredOrder CreateTestInsuredOrder()
        {
            return new InsuredOrder("Планшет", "TB-002", "Петров", 2, "16.07.2024 10:00",
                                    OrderType.Regular, "СберСтрах", 50000.0);
        }
    }
}
