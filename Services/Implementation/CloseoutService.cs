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
    public class CloseoutService : ICloseoutService
    {
        private readonly ICloseoutRepository _closeoutRepository;
        public CloseoutService(ICloseoutRepository closeoutRepository)
        {
            _closeoutRepository = closeoutRepository;
        }

        public Task<IEnumerable<Closeout>> GetCloseouts(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy)
        {
            return _closeoutRepository.GetCloseout(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portfolio, broker, customer, orderBy);
        }
    }
}
