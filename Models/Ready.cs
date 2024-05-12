using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Ready
    {
        public int DealNo { get; set; }
        public DateTime DealDate { get; set; }
        public string BrCode { get; set; }
        public string BrName { get; set; }
        public string PS { get; set; }
        public string SN { get; set; }
        public decimal CoverRate { get; set; }
        public decimal CustRate { get; set; }
        public string CCY { get; set; }
        public decimal Amount { get; set; }
        public decimal EquivalentPKR { get; set; }
        public decimal Revenue { get; set; }
        public decimal Spread { get; set; }
        public string Dealer { get; set; }
        public string ContactPerson { get; set; }
        public string Segment { get; set; }
        public string CTRCCY { get; set; }
        public string DealNotes { get; set; }
    }
}
