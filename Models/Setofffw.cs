namespace OSR_API.Models
{
    public class Setofffw
    {
        public string DealNumber { get; set; }
        public DateTime? TakeDownDate { get; set; }
        public string BrCode { get; set; }
        public string Curr { get; set; }
        public string Type { get; set; }
        public string Port { get; set; }
        public decimal TakeDownAmount { get; set; }
        public decimal CustomerRate { get; set; }
        public decimal? EquivalentPKR { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? DealDate { get; set; }
        public DateTime? OptionDate { get; set; }
        public string Customer { get; set; }
        public int TotalBookedDays { get; set; }
        public int TotalOptionDays { get; set; }
        public int TotalUtilizeUntilizedDays { get; set; }
        public decimal PremiumUtilizedProfit { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal Profit { get; set; }
        public int RemainDays { get; set; }
        public decimal PremiumLoss { get; set; }
        public decimal Loss { get; set; }
        public decimal? WeightedAvgDaysUtilized { get; set; }
        public decimal? WeightedAvgDaysUnutilized { get; set; }
        public string Remarks { get; set; }
        public decimal? USDEq { get; set; }
        public string CTRCCY { get; set; }
        public string DealersID { get; set; }
    }
}
