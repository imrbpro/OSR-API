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

        public Task<IEnumerable<Discounting>> GetDiscounting()
        {
            return _discountingRepository.GetDiscounting();
        }
    }
}
