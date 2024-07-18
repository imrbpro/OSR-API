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
        public async Task<IEnumerable<Closeout>> GetCloseout()
        {
            const string storedProcedure = "spGetAllCloseout";
            SqlParameter[] sqlParameters = null;
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
