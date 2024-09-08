using Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ReadyService : IReadyService
    {
        private readonly IReadyRepository _readyRepository;
        public ReadyService(IReadyRepository readyRepository)
        {
            _readyRepository = readyRepository;
        }
        public Task<IEnumerable<Ready>> GetReady(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string trader, string customer, char ps, int orderBy)
        {
            return _readyRepository.GetReady(dealNo, dealNoTo, dealDate, dealDateTo, valueDate, valueDateTo, brCode, ccy, portFolio, trader, customer, ps, orderBy);
        }
    }
}
