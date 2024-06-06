namespace OSR_API.Models
{
    public class Forward
    {
        public string DEALNO { get; set; }
        public DateTime? DEALDATE { get; set; }
        public DateTime? ODATE { get; set; }
        public DateTime? VDATE { get; set; }
        public int? Days { get; set; }
        public decimal TotalPremium { get; set; }
        public string BRCODE { get; set; }
        public string BRNAME { get; set; }
        public decimal? COVERRATE { get; set; }
        public decimal? CUSTRATE { get; set; }
        public string PS { get; set; }
        public string CCY { get; set; }
        public string PORT { get; set; }
        public decimal AMOUNT { get; set; }
        public string EQPKR { get; set; }
        public string CNO { get; set; }
        public string SN { get; set; }
        public string DEALTEXT { get; set; }
        public decimal? SPOTRATE { get; set; }
        public string CTRCCY { get; set; }
        public decimal? CTRAMT { get; set; }
        public string TRAD { get; set; }
        public decimal? CORPSPREADAMT { get; set; }
        public string DealNotes { get; set; }
        public decimal? USDEq { get; set; }
        public decimal? EqPakRs { get; set; }
        public decimal? exprofit { get; set; }
    }
}
