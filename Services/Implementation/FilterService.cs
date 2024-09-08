using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _FilterRepository;
        public FilterService(IFilterRepository FilterRepository)
        {
            _FilterRepository = FilterRepository;
        }

        public Task<IEnumerable<string>> GetBranchCode()
        {
            return _FilterRepository.GetBranchCode();
        }

        public Task<IEnumerable<string>> GetCurrency()
        {
            return _FilterRepository.GetCurrency();
        }

        public Task<IEnumerable<string>> GetPortfolio()
        {
            return _FilterRepository.GetPortfolio();
        }

        public Task<IEnumerable<string>> GetTrader()
        {
            return _FilterRepository.GetTrader();
        }
    }
}
