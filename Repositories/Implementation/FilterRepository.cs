using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Helpers.Interface;

namespace Repositories.Implementation
{
    public class FilterRepository : IFilterRepository
    {
        private readonly IDbHelper _dbHelper;
        public FilterRepository(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<string>> GetBranchCode()
        {
            const string storedProcedure = "GetBranchCode";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<string>(); ;
            }

            var dealnoList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                dealnoList.Add(row["DEALSRCE"]?.ToString());                
            }
            return dealnoList;
        }

        public async Task<IEnumerable<string>> GetCurrency()
        {
            const string storedProcedure = "GetCurr";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<string>(); ;
            }

            var currencyList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                currencyList.Add(row["CCY"]?.ToString());
            }
            return currencyList;
        }

        public async Task<IEnumerable<string>> GetPortfolio()
        {
            const string storedProcedure = "Getport";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<string>(); ;
            }

            var portfolioList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                portfolioList.Add(row["Portfolio"]?.ToString());
            }
            return portfolioList;
        }

        public async Task<IEnumerable<string>> GetTrader()
        {
            const string storedProcedure = "Gettrad";
            SqlParameter[] sqlParameters = null;
            var dataTable = await _dbHelper.Get(storedProcedure, sqlParameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return Enumerable.Empty<string>(); ;
            }

            var traderList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                traderList.Add(row["Trader"]?.ToString());
            }
            return traderList;
        }
    }
}
