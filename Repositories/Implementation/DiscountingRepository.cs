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
        public async Task<IEnumerable<Discounting>> GetDiscounting(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string broker, string trader, string customer, char ps, int orderBy)
        {
            const string storedProcedure = "GetDailyDiscountingReport";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@dealNo", dealNo),
                new SqlParameter("@dealNoTo", dealNoTo),
                new SqlParameter("@dealDate", dealDate),
                new SqlParameter("@dealDateTo", dealDateTo),
                new SqlParameter("@valueDate", valueDate),
                new SqlParameter("@valueDateTo", valueDateTo),
                new SqlParameter("@brCode", brCode),
                new SqlParameter("@ccy", ccy),
                new SqlParameter("@portFolio", portFolio),
                new SqlParameter("@broker", broker),
                new SqlParameter("@trader", trader),
                new SqlParameter("@customer", customer),
                new SqlParameter("@ps", ps),
                new SqlParameter("@orderBy", orderBy)
            };
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
