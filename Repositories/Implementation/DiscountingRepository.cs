using Models;
using Repositories.Helpers.Interface;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class DiscountingRepository : IDiscountingRepository
    {
        private readonly IDbHelper _dbHelper;
        public DiscountingRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Discounting>> GetDiscounting()
        {
            const string storedProcedure = "spGetAllDiscounting";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Discounting>(); ;
            }

            var discountingList = new List<Discounting>();
            foreach (DataRow row in dataTable.Rows)
            {
                discountingList.Add(new Discounting
                {
                    DealNo = Convert.ToInt32(row["DEALNO"]),
                    DealDate = DateTime.ParseExact(row["dealdate"].ToString(), "M/d/yyyy", CultureInfo.InvariantCulture),
                    ValueDate = row["VDATE"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["VDATE"]),
                    RemDays = row["REMDAYS"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["REMDAYS"]),
                    CntPerson = row["CNTPERSON"].ToString(),
                    BrCode = row["BRCODE"].ToString(),
                    BrName = row["BRNAME"].ToString(),
                    CoverRate = Convert.ToDecimal(row["COVERRATE"]),
                    BaseRate = Convert.ToDecimal(row["BASERATE"]),
                    CustRate = Convert.ToDecimal(row["CUSTRATE"]),
                    Yield = Convert.ToDecimal(row["YIELD"]),
                    PS = row["PS"].ToString(),
                    Ccy = row["CCY"].ToString(),
                    Port = row["PORT"].ToString(),
                    CcyAmt = Convert.ToDecimal(row["CCYAMT"]),
                    DiscAmt1 = Convert.ToDecimal(row["DISCAMT1"]),
                    Cno = row["CNO"].ToString(),
                    Sn = row["SN"].ToString(),
                    Dealer = row["DEALER"].ToString(),
                    CustRate1 = Convert.ToDecimal(row["CUSTRATE1"]),
                    DiscAmt2 = Convert.ToDecimal(row["DISCAMT2"]),
                    Adj = row["ADJ"].ToString(),
                    Vol = row["VOL"].ToString(),
                    EquivalentUSD = Convert.ToDecimal(row["Equiv USD"]),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    EquivalentPKR = Convert.ToDecimal(row["Eq PKR"]),
                    ExProfit = Convert.ToDecimal(row["Ex-Profit"]),
                    Spread = Convert.ToDecimal(row["SPREAD"])
                });
            }
            return discountingList;
        }
    } 
}
