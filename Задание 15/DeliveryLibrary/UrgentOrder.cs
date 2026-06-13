namespace DeliveryLibrary
{
    public class UrgentOrder : Order
    {
        public double UrgencySurchargeRate { get; set; }
        public readonly UrgencyLevel UrgencyLevel;

        public UrgentOrder(string productName, string articleNumber, string courierSurname,
                           int orderNumber, string deliveryDateTime,
                           double urgencySurchargeRate, UrgencyLevel urgencyLevel)
            : base(productName, articleNumber, courierSurname, orderNumber, deliveryDateTime, OrderType.Urgent)
        {
            UrgencySurchargeRate = urgencySurchargeRate;
            UrgencyLevel = urgencyLevel;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];

            string level;
            switch (UrgencyLevel)
            {
                case UrgencyLevel.WithinDay:          level = "в течение суток";         break;
                case UrgencyLevel.WithinThreeHours:   level = "в течение трех часов";    break;
                default:                               level = "в течение часа";          break;
            }

            info[2] = $"Срочный заказ. Надбавка: {UrgencySurchargeRate:F2}. Срочность: {level}.";
            return info;
        }
    }
}
