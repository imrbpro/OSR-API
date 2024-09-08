using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IFilterRepository
    {
        Task<IEnumerable<string>> GetBranchCode();
        Task<IEnumerable<string>> GetCurrency();
        Task<IEnumerable<string>> GetPortfolio();
        Task<IEnumerable<string>> GetTrader();
    }
}
