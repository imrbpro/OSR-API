using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Helpers.Implementation;
using Models;
using Repositories.Interface;
using Repositories.Helpers.Interface;

namespace Repositories.Implementation
{
    public class OutstandingFWDRepository : IOutstandingFWDRepository
    {
        public readonly IDbHelper _dbHelper;
        public OutstandingFWDRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<IEnumerable<OutstandingFWD>> GetOuttandingFWD(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portFolio, string branchcode, string trader, string customer, int orderBy)
        {
            const string storedProcedure = "OutstandingFWDsFW";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@dealNo", dealNo),
                new SqlParameter("@dealNoTo", dealNoTo),
                new SqlParameter("@contractDate", contractDate),
                new SqlParameter("@contractDateTo", contractDateTo),
                new SqlParameter("@valueDate", valueDate),
                new SqlParameter("@valueDateTo", valueDateTo),
                new SqlParameter("@entryDate", entryDate),
                new SqlParameter("@entryDateTo", entryDateTo),
                new SqlParameter("@CCY", ccy),
                new SqlParameter("@PortFolio", portFolio),
                new SqlParameter("@Branchcode", branchcode),
                new SqlParameter("@trader", trader),
                new SqlParameter("@Customer", customer),
                new SqlParameter("@OrderBy", orderBy)
           };

            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<OutstandingFWD>();
            }

            var outstandingFwdList = new List<OutstandingFWD>();
            foreach (DataRow row in dataTable.Rows)
            {
                outstandingFwdList.Add(new OutstandingFWD
                {
                    DealNo = row["DEALNO"] as string,
                    DealDate = row["DEALDATE"] as string,
                    OptionStartDate = row["OPTIONSTARTDATE"] as string,
                    ValueDate = row["VALUEDATE"] as string,
                    CoverRate = row["COVERRATE"] == DBNull.Value ? 0 : Convert.ToDecimal(row["COVERRATE"]),
                    CustomerRate = row["CustomerRate"] == DBNull.Value ? 0 : Convert.ToDecimal(row["CustomerRate"]),
                    BrCode = row["BRCODE"] as string,
                    CustName = row["CUSTNAME"] as string,
                    CurrencyCodes = row["CurrencyCodes"] as string,
                    BookedAmount = row["BOOKEDAMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(row["BOOKEDAMOUNT"]),
                    SetOffAmount = row["SETOFFAMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(row["SETOFFAMOUNT"]),
                    BalanceAmount = row["BALANCEAMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(row["BALANCEAMOUNT"]),
                    TotalPremium = row["TOTALPREMIUM"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TOTALPREMIUM"]),
                    TotalOptionDays = row["TOTALOPTIONDAYS"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TOTALOPTIONDAYS"]),
                    USDEq = row["USDEQ"] == DBNull.Value ? 0 : Convert.ToDecimal(row["USDEQ"]),
                    Remarks = row["REMARKS"] as string,
                    Type = row["TYPE"] as string,
                    TotalOptionPremium = row["TOTALOPTIONPREMIUM"] as string
                });
            }

            return outstandingFwdList;
        }
    }
}
