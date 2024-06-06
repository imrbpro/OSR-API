using OSR_API.Models;
using OSR_API.Repositories.Interface;
using Repositories.Helpers.Interface;
using System.Data;
using System.Data.SqlClient;

namespace OSR_API.Repositories.Implementation
{
    public class SetofffwRepository : ISetofffwRepository
    {
        private readonly IDbHelper _dbHelper;
        public SetofffwRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Setofffw>> GetSetOffFw()
        {
            const string storedProcedure = "spGetAllDiscounting";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Setofffw>(); ;
            }

            var SetofffwList = new List<Setofffw>();
            foreach (DataRow row in dataTable.Rows)
            {
                SetofffwList.Add(new Setofffw
                {
                    DealNumber = row["Deal #"]?.ToString(),
                    TakeDownDate = (DateTime?)row["Take down date"],
                    BrCode = row["Br Code"]?.ToString(),
                    Curr = row["Curr"]?.ToString(),
                    Type = row["Type"]?.ToString(),
                    Port = row["Port"]?.ToString(),
                    TakeDownAmount = (decimal)row["Take Down Amount"],
                    CustomerRate = (decimal)row["Customer Rate"],
                    EquivalentPKR = (decimal?)row["Equivalent PKR"],
                    MaturityDate = (DateTime?)row["Maturity Date"],
                    DealDate = (DateTime?)row["Deal Date"],
                    OptionDate = (DateTime?)row["Option Date"],
                    Customer = row["Customer"]?.ToString(),
                    TotalBookedDays = (int)row["Total Booked Days"],
                    TotalOptionDays = (int)row["Total Option Days"],
                    TotalUtilizeUntilizedDays = (int)row["Total Utilize/Untilized Days"],
                    PremiumUtilizedProfit = (decimal)row["Premium Utilized Profit"],
                    TotalPremium = (decimal)row["Total premium"],
                    Profit = (decimal)row["Profit"],
                    RemainDays = (int)row["Remain. Days"],
                    PremiumLoss = (decimal)row["Premium Loss"],
                    Loss = (decimal)row["Loss"],
                    WeightedAvgDaysUtilized = (decimal?)row["Weighted Avg Days utilized"],
                    WeightedAvgDaysUnutilized = (decimal?)row["Weighted Avg Days unutilized"],
                    Remarks = row["Remarks"]?.ToString(),
                    USDEq = (decimal?)row["USD Eq."],
                    CTRCCY = row["CTRCCY"]?.ToString(),
                    DealersID = row["Dealers ID"]?.ToString(),
                });
            }
            return SetofffwList;
        }
    }
}
