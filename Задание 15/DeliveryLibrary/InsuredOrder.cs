namespace DeliveryLibrary
{
    public class InsuredOrder : Order
    {
        public string InsuranceCompanyName { get; set; }
        public double InsuranceAmount { get; set; }

        public InsuredOrder(string productName, string articleNumber, string courierSurname,
                            int orderNumber, string deliveryDateTime, OrderType orderType,
                            string insuranceCompanyName, double insuranceAmount)
            : base(productName, articleNumber, courierSurname, orderNumber, deliveryDateTime, orderType)
        {
            InsuranceCompanyName = insuranceCompanyName;
            InsuranceAmount = insuranceAmount;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Застрахован: {InsuranceCompanyName}. Сумма страховки: {InsuranceAmount:F2} руб.";
            return info;
        }
    }
}
