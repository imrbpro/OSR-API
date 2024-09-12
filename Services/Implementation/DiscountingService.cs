using Models;
using OSR_API.Models.dto;
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

        public Task<IEnumerable<Discounting>> GetDiscounting(DiscountingDto discounting)
        {
            return _discountingRepository.GetDiscounting(discounting);
        }
    }
}
