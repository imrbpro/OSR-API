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
    public class DiscountingService : IDiscountingService
    {
        private readonly IDiscountingRepository _discountingRepository;
        public DiscountingService(IDiscountingRepository discountingRepository)
        {
            _discountingRepository = discountingRepository;
        }

        public Task<IEnumerable<Discounting>> GetDiscounting(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string broker, string trader, string customer, char ps, int orderBy)
        {
            return _discountingRepository.GetDiscounting(dealNo, dealNoTo, dealDate, dealDateTo, valueDate, valueDateTo, brCode, ccy, portFolio, broker, trader, customer, ps, orderBy);
        }
    }
}
