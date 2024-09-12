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
using Models.dto;

namespace Repositories.Implementation
{
    public class ReadyRepository : IReadyRepository
    {
        private readonly IDbHelper _dbHelper;
        public ReadyRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Ready>> GetReady(ReadyDto ready)
        {
            const string storedProcedure = "GetDailyReadyReport";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dealNo", ready.DealNo),
                new SqlParameter("@dealNoTo", ready.DealNoTo),
                new SqlParameter("@dealDate", ready.DealDate),
                new SqlParameter("@dealDateTo", ready.DealDateTo),
                new SqlParameter("@valueDate", ready.ValueDate),
                new SqlParameter("@valueDateTo", ready.ValueDateTo),
                new SqlParameter("@brCode", ready.BrCode),
                new SqlParameter("@ccy", ready.Ccy),
                new SqlParameter("@portFolio", ready.PortFolio),
                new SqlParameter("@trader", ready.Trader),
                new SqlParameter("@customer", ready.Customer),
                new SqlParameter("@PS", ready.Ps),
                new SqlParameter("@orderBy", ready.OrderBy)
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
