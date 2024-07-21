using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OutstandingFWD
    {
        public string DealNo { get; set; }
        public string DealDate { get; set; }
        public string OptionStartDate { get; set; }
        public string ValueDate { get; set; }
        public decimal CoverRate { get; set; }
        public decimal CustomerRate { get; set; }
        public string BrCode { get; set; }
        public string CustName { get; set; }
        public string CurrencyCodes { get; set; }
        public decimal BookedAmount { get; set; }
        public decimal SetOffAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalOptionDays { get; set; }
        public decimal USDEq { get; set; }
        public string Remarks { get; set; }
        public string Type { get; set; }
        public string TotalOptionPremium { get; set; }
    }
}
