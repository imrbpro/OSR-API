using OSR_API.Models;
using OSR_API.Repositories.Interface;
using Repositories.Helpers.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace OSR_API.Repositories.Implementation
{
    public class ForwardRepository : IForwardRepository
    {
        private readonly IDbHelper _dbHelper;
        public ForwardRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Forward>> GetForward()
        {
            const string storedProcedure = "spGetAllForward";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Forward>(); ;
            }

            var forwardList = new List<Forward>();
            foreach (DataRow row in dataTable.Rows)
            {
                forwardList.Add(new Forward
                {
                    DEALNO = row["DEALNO"]?.ToString(),
                    DEALDATE = DateTime.ParseExact(row["DEALDATE"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    ODATE = DateTime.ParseExact(row["ODATE"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    VDATE = DateTime.ParseExact(row["VDATE"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    Days = Convert.ToInt32(row["Days"]),
                    TotalPremium = Convert.ToDecimal(row["TotalPremium"]),
                    BRCODE = row["BRCODE"]?.ToString(),
                    BRNAME = row["BRNAME"]?.ToString(),
                    COVERRATE = Convert.ToDecimal(row["COVERRATE"]),
                    CUSTRATE = Convert.ToDecimal(row["CUSTRATE"]),
                    PS = row["PS"]?.ToString(),
                    CCY = row["CCY"]?.ToString(),
                    PORT = row["PORT"]?.ToString(),
                    AMOUNT = Convert.ToDecimal(row["AMOUNT"]),
                    EQPKR = row["EQPKR"]?.ToString(),
                    CNO = row["CNO"]?.ToString(),
                    SN = row["SN"]?.ToString(),
                    DEALTEXT = row["DEALTEXT"]?.ToString(),
                    SPOTRATE = Convert.ToDecimal(row["SPOTRATE"]),
                    CTRCCY = row["CTRCCY"]?.ToString(),
                    CTRAMT = Convert.ToDecimal(row["CTRAMT"]),
                    TRAD = row["TRAD"]?.ToString(),
                    CORPSPREADAMT = Convert.ToDecimal(row["CORPSPREADAMT"]),
                    DealNotes = row["Deal Notes"]?.ToString(),
                    USDEq = Convert.ToDecimal(row["USD Eq"]),
                    EqPakRs = Convert.ToDecimal(row["Eq. Pak Rs"]),
                    exprofit = Convert.ToDecimal(row["exprofit"]),
                });
            }
            return forwardList;
        }
    }
}
