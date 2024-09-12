using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Closeout
    {
        public string DEALNO { get; set; }
        public string DEALDATE { get; set; }
        public string ODATE { get; set; }
        public string MaturityDate { get; set; }
        public string days { get; set; }
        public string contact { get; set; }
        public decimal SPOTRATE_8 { get; set; }
        public string BRCODE { get; set; }
        public string BRNAME { get; set; }
        public string PS { get; set; }
        public string PORT { get; set; }
        public string CCY { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal CUSTRATE { get; set; }
        public string TotalPremuim { get; set; }
        public decimal EQUIVPKR { get; set; }
        public string CUSTOMER { get; set; }
        public string Remarks { get; set; }
    }
}
