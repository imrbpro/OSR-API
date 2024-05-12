using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Discounting
    {
        public int DealNo { get; set; }
        public DateTime DealDate { get; set; }
        public DateTime? ValueDate { get; set; } // nullable for VDATE
        public int? RemDays { get; set; } // nullable for REMDAYS
        public string CntPerson { get; set; }
        public string BrCode { get; set; }
        public string BrName { get; set; }
        public decimal CoverRate { get; set; }
        public decimal BaseRate { get; set; }
        public decimal CustRate { get; set; }
        public decimal Yield { get; set; }
        public string PS { get; set; }
        public string Ccy { get; set; }
        public string Port { get; set; }
        public decimal CcyAmt { get; set; }
        public decimal DiscAmt1 { get; set; }
        public string Cno { get; set; }
        public string Sn { get; set; }
        public string Dealer { get; set; }
        public decimal CustRate1 { get; set; }
        public decimal DiscAmt2 { get; set; }
        public string Adj { get; set; }
        public string Vol { get; set; }
        public decimal EquivalentUSD { get; set; }
        public decimal Amount { get; set; }
        public decimal EquivalentPKR { get; set; }
        public decimal ExProfit { get; set; }
        public decimal Spread { get; set; }
    }
}
