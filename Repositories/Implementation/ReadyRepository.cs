using Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Helpers.Interface;
using System.Globalization;

namespace Repositories.Implementation
{
    public class ReadyRepository : IReadyRepository
    {
        private readonly IDbHelper _dbHelper;
        public ReadyRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Ready>> GetReady(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string trader, string customer, char ps, int orderBy)
        {
            const string storedProcedure = "GetDailyReadyReport";
            SqlParameter[] parameters = new SqlParameter[]
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
                new SqlParameter("@trader", trader),
                new SqlParameter("@customer", customer),
                new SqlParameter("@PS", ps),
                new SqlParameter("@orderBy", orderBy)
            };
            var dataTable = await _dbHelper.Get(storedProcedure, parameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Ready>();
            }
            var readyList = new List<Ready>();
            foreach (DataRow row in dataTable.Rows)
            {
                readyList.Add(new Ready
                {
                    DealNo = Convert.ToInt32(row["dealno"]),
                    DealDate = DateTime.ParseExact(row["dealdate"].ToString(), "M/d/yyyy", CultureInfo.InvariantCulture),
                    BrCode = row["brcode"].ToString(),
                    BrName = row["Brname"].ToString(),
                    PS = row["PS"].ToString(),
                    SN = row["SN"].ToString(),
                    CoverRate = Convert.ToDecimal(row["CoverRate"]),
                    CustRate = Convert.ToDecimal(row["CustRate"]),
                    CCY = row["CCY"].ToString(),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    EquivalentPKR = Convert.ToDecimal(row["EQUILANT_PKR"]),
                    Revenue = Convert.ToDecimal(row["REVENUE"]),
                    Spread = Convert.ToDecimal(row["spread"]),
                    Dealer = row["DEALER"].ToString(),
                    ContactPerson = row["Contact Person"].ToString(),
                    Segment = row["SEGMENT"].ToString(),
                    CTRCCY = row["CTRCCY"].ToString(),
                    DealNotes = row["Deal Notes"].ToString(),
                });
            }
            return readyList;
        }
    }
}
