using System;
using System.Collections;
using System.Collections.Generic;

namespace DeliveryLibrary
{
    public class Shipment : IEnumerable<Order>
    {
        public string CourierSurname { get; set; }
        public DateTime DeliveryDate;

        private List<Order> orders;

        public int Count => orders.Count;

        public Shipment(string courierSurname, string deliveryDate, IEnumerable<Order> orderCollection)
        {
            CourierSurname = courierSurname;
            DeliveryDate = DateTime.Parse(deliveryDate);
            orders = new List<Order>();

            foreach (var order in orderCollection)
            {
                if (order.CourierSurname == courierSurname &&
                    order.DeliveryDateTime.Date == DeliveryDate.Date)
                {
                    orders.Add(order);
                }
            }
        }

        public IEnumerator<Order> GetEnumerator() => orders.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
