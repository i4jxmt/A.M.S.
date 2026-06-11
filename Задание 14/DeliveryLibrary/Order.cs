using System;

namespace DeliveryLibrary
{
    public class Order
    {
        public string ProductName { get; set; }
        public readonly string ArticleNumber;
        public string CourierSurname { get; set; }
        public readonly int OrderNumber;
        public DateTime DeliveryDateTime { get; set; }
        public readonly OrderType OrderType;

        public Order(string productName, string articleNumber, string courierSurname,
                     int orderNumber, string deliveryDateTime, OrderType orderType)
        {
            ProductName = productName;
            ArticleNumber = articleNumber;
            CourierSurname = courierSurname;
            OrderNumber = orderNumber;
            OrderType = orderType;

            if (!DateTime.TryParse(deliveryDateTime, out DateTime dt))
                throw new ArgumentException("Неверный формат даты и времени доставки");
            DeliveryDateTime = dt;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"Заявка №{OrderNumber}: {ProductName}";

            string orderType = OrderType == OrderType.Urgent ? "срочный" : "обычный";
            info[1] = $"Артикул: {ArticleNumber}. Курьер: {CourierSurname}. " +
                      $"Доставка: {DeliveryDateTime:dd.MM.yyyy HH:mm}. Тип: {orderType}.";

            return info;
        }
    }
}
