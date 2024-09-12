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
using OSR_API.Models.dto;

namespace Repositories.Implementation
{
    public class CloseoutRepository : ICloseoutRepository
    {
        public readonly IDbHelper _dbHelper;
        public CloseoutRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Closeout>> GetCloseout(CloseoutDto closeout)
        {
            const string storedProcedure = "GetCloseOut";
            SqlParameter[] sqlParameters =  new SqlParameter[]
        {
            new SqlParameter("@dealNo", closeout.DealNo),
            new SqlParameter("@dealNoTo", closeout.DealNoTo), 
            new SqlParameter("@ContractDate", closeout.ContractDate),
            new SqlParameter("@ContractDateTo", closeout.ContractDateTo), 
            new SqlParameter("@ValueDate", closeout.ValueDate),
            new SqlParameter("@ValueDateTo", closeout.ValueDateTo), 
            new SqlParameter("@EntryDate", closeout.EntryDate),
            new SqlParameter("@EntryDateTo", closeout.EntryDateTo), 
            new SqlParameter("@CCY", closeout.Ccy),
            new SqlParameter("@PortFolio", closeout.Portfolio),
            new SqlParameter("@Broker", closeout.Broker), 
            new SqlParameter("@Customer", closeout.Customer),
            new SqlParameter("@OrderBy", closeout.OrderBy) 
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
                    TotalPremuim = row["TotalPremuim"].ToString(),
                    EQUIVPKR = Convert.ToDecimal(row["EQUIVPKR"]),
                    CUSTOMER = row["CUSTOMER"].ToString(),
                    Remarks = row["Remarks"].ToString()
                });
            }
            return closeoutList;
        }
    }
}
