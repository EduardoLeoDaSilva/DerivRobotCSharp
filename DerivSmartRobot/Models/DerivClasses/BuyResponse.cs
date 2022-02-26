namespace DerivSmartRobot.Models.DerivClasses;


    public class BuyResponse
    {
        public double balance_after { get; set; }
        public decimal buy_price { get; set; }
        public long contract_id { get; set; }
        public string longcode { get; set; }
        public double payout { get; set; }
        public int purchase_time { get; set; }
        public string shortcode { get; set; }
        public int start_time { get; set; }
        public long transaction_id { get; set; }
    }

