using Models;
using Repositories.Helpers.Interface;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class CloseoutRepository : ICloseoutRepository
    {
        public readonly IDbHelper _dbHelper;
        public CloseoutRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Closeout>> GetCloseout(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy)
        {
            const string storedProcedure = "GetCloseOut";
            SqlParameter[] sqlParameters =  new SqlParameter[]
        {
            new SqlParameter("@dealNo", dealNo),
            new SqlParameter("@dealNoTo", dealNoTo), 
            new SqlParameter("@ContractDate", contractDate),
            new SqlParameter("@ContractDateTo", contractDateTo), 
            new SqlParameter("@ValueDate", valueDate),
            new SqlParameter("@ValueDateTo", valueDateTo), 
            new SqlParameter("@EntryDate", entryDate),
            new SqlParameter("@EntryDateTo", entryDateTo), 
            new SqlParameter("@CCY", ccy),
            new SqlParameter("@PortFolio", portfolio),
            new SqlParameter("@Broker", broker), 
            new SqlParameter("@Customer", customer),
            new SqlParameter("@OrderBy", orderBy) 
        };
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Closeout>();
            }

            var closeoutList = new List<Closeout>();
            foreach (DataRow row in dataTable.Rows)
            {
                closeoutList.Add(new Closeout
                {
                    DEALNO = row["DEALNO"].ToString(),
                    DEALDATE = row["DEALDATE"].ToString(),
                    ODATE = row["ODATE"].ToString(),
                    MaturityDate = row["MaturityDate"].ToString(),
                    days = row["days"].ToString(),
                    contact = row["contact"].ToString(),
                    SPOTRATE_8 = Convert.ToDecimal(row["SPOTRATE_8"]),
                    BRCODE = row["BRCODE"].ToString(),
                    BRNAME = row["BRNAME"].ToString(),
                    PS = row["PS"].ToString(),
                    PORT = row["PORT"].ToString(),
                    CCY = row["CCY"].ToString(),
                    AMOUNT = Convert.ToDecimal(row["AMOUNT"]),
                    CUSTRATE = Convert.ToDecimal(row["CUSTRATE"]),
                    TotalPremuim = Convert.ToDecimal(row["TotalPremuim"]),
                    EQUIVPKR = Convert.ToDecimal(row["EQUIVPKR"]),
                    CUSTOMER = row["CUSTOMER"].ToString(),
                    Remarks = row["Remarks"].ToString()
                });
            }
            return closeoutList;
        }
    }
}
