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
        public async Task<IEnumerable<Ready>> GetReady()
        {
            const string storedProcedure = "spGetAllReady"; 
            SqlParameter[] parameters = null;
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
