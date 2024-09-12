using OSR_API.Models;
using OSR_API.Models.dto;
using OSR_API.Repositories.Interface;
using Repositories.Helpers.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace OSR_API.Repositories.Implementation
{
    public class SetofffwRepository : ISetofffwRepository
    {
        private readonly IDbHelper _dbHelper;
        public SetofffwRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Setofffw>> GetSetOffFw(SetOffDto setOff)
        {
            const string storedProcedure = "GetSetofffwd";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@dealNo", setOff.DealNo),
                new SqlParameter("@dealNoTo", setOff.DealNoTo),
                new SqlParameter("@ContractDate", setOff.ContractDate),
                new SqlParameter("@ContractDateTo", setOff.ContractDateTo),
                new SqlParameter("@ValueDate", setOff.ValueDate),
                new SqlParameter("@ValueDateto", setOff.ValueDateTo),
                new SqlParameter("@EntryDate", setOff.EntryDate),
                new SqlParameter("@EntryDateTo", setOff.EntryDateTo),
                new SqlParameter("@CCY", setOff.Ccy),
                new SqlParameter("@PortFolio", setOff.Portfolio),
                new SqlParameter("@Trad", setOff.Trad),
                new SqlParameter("@Customer", setOff.Customer),
                new SqlParameter("@OrderBy", setOff.OrderBy)
            };
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<Setofffw>();
            }

            var setoffList = new List<Setofffw>();
            foreach (DataRow row in dataTable.Rows)
            {
                setoffList.Add(new Setofffw
                {
                    DealNumber = row["DealNo"]?.ToString(),
                    TakeDownDate =  DateTime.ParseExact(row["Take down date"].ToString(), "dd-MMM-yy", CultureInfo.InvariantCulture),
                    BrCode = row["Br Code"]?.ToString(),
                    Curr = row["Curr"]?.ToString(),
                    Type = row["Type"]?.ToString(),
                    Port = row["Port"]?.ToString(),
                    TakeDownAmount = row["Take Down Amount"] is DBNull ? 0 : Convert.ToDecimal(row["Take Down Amount"]),
                    CustomerRate = row["Customer Rate"] is DBNull ? 0 : Convert.ToDecimal(row["Customer Rate"]),
                    EquivalentPKR = row["Equivalent PKR"] is DBNull ? null : (decimal?)Convert.ToDecimal(row["Equivalent PKR"]),
                    MaturityDate = DateTime.ParseExact(row["Maturity Date"].ToString(), "dd-MMM-yy", CultureInfo.InvariantCulture),
                    DealDate = DateTime.ParseExact(row["Deal Date"].ToString(), "dd-MMM-yy", CultureInfo.InvariantCulture),
                    OptionDate = DateTime.ParseExact(row["Option Date"].ToString(), "dd-MMM-yy", CultureInfo.InvariantCulture),
                    Customer = row["Customer"]?.ToString(),
                    TotalBookedDays = row["Total Booked Days"] is DBNull ? 0 : Convert.ToInt32(row["Total Booked Days"]),
                    TotalOptionDays = row["Total Option Days"] is DBNull ? 0 : Convert.ToInt32(row["Total Option Days"]),
                    TotalUtilizeUntilizedDays = row["Total Utilize/Untilized Days"] is DBNull ? 0 : Convert.ToInt32(row["Total Utilize/Untilized Days"]),
                    PremiumUtilizedProfit = row["Premium Utilized"] is DBNull ? 0 : Convert.ToDecimal(row["Premium Utilized"]),
                    TotalPremium = row["Total premium"] is DBNull ? 0 : Convert.ToDecimal(row["Total premium"]),
                    Profit = row["Profit"] is DBNull ? 0 : Convert.ToDecimal(row["Profit"]),
                    RemainDays = row["Remain. Days"] is DBNull ? 0 : Convert.ToInt32(row["Remain. Days"]),
                    PremiumLoss = row["Premium Loss"] is DBNull ? 0 : Convert.ToDecimal(row["Premium Loss"]),
                    Loss = row["Loss"] is DBNull ? null : (decimal?)Convert.ToDecimal(row["Loss"]),
                    WeightedAvgDaysUtilized = row["Weighted Avg Days utilized"] is DBNull ? null : (decimal?)Convert.ToDecimal(row["Weighted Avg Days utilized"]),
                    WeightedAvgDaysUnutilized = row["Weighted Avg Days unutilized"] is DBNull ? null : (decimal?)Convert.ToDecimal(row["Weighted Avg Days unutilized"]),
                    Remarks = row["Remarks"]?.ToString(),
                    USDEq = row["USD Eq."] is DBNull ? null : (decimal?)Convert.ToDecimal(row["USD Eq."]),
                    CTRCCY = row["CTRCCY"]?.ToString(),
                    DealersID = row["DealersId"]?.ToString(),
                });
            }

            return setoffList;
        }

    }
}
