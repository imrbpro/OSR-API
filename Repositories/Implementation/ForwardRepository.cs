using OSR_API.Models;
using OSR_API.Repositories.Interface;
using Repositories.Helpers.Interface;
using System.Data;
using System.Data.SqlClient;

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
            const string storedProcedure = "spGetAllDiscounting";
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
                    DEALDATE = (DateTime?)row["DEALDATE"],
                    ODATE = (DateTime?)row["ODATE"],
                    VDATE = (DateTime?)row["VDATE"],
                    Days = (int?)row["Days"],
                    TotalPremium = (decimal)row["TotalPremium"],
                    BRCODE = row["BRCODE"]?.ToString(),
                    BRNAME = row["BRNAME"]?.ToString(),
                    COVERRATE = (decimal?)row["COVERRATE"],
                    CUSTRATE = (decimal?)row["CUSTRATE"],
                    PS = row["PS"]?.ToString(),
                    CCY = row["CCY"]?.ToString(),
                    PORT = row["PORT"]?.ToString(),
                    AMOUNT = (decimal)row["AMOUNT"],
                    EQPKR = row["EQPKR"]?.ToString(),
                    CNO = row["CNO"]?.ToString(),
                    SN = row["SN"]?.ToString(),
                    DEALTEXT = row["DEALTEXT"]?.ToString(),
                    SPOTRATE = (decimal?)row["SPOTRATE"],
                    CTRCCY = row["CTRCCY"]?.ToString(),
                    CTRAMT = (decimal?)row["CTRAMT"],
                    TRAD = row["TRAD"]?.ToString(),
                    CORPSPREADAMT = (decimal?)row["CORPSPREADAMT"],
                    DealNotes = row["DealNotes"]?.ToString(),
                    USDEq = (decimal?)row["USDEq"],
                    EqPakRs = (decimal?)row["EqPakRs"],
                    exprofit = (decimal?)row["exprofit"],
                });
            }
            return forwardList;
        }
    }
}
