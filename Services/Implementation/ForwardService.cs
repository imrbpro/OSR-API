using OSR_API.Models;
using OSR_API.Repositories.Interface;
using OSR_API.Services.Interface;

namespace OSR_API.Services.Implementation
{
    public class ForwardService : IForwardService
    {
        private readonly IForwardRepository _ForwardRepository;
        public ForwardService(IForwardRepository ForwardRepository)
        {
            _ForwardRepository = ForwardRepository;
        }

        public Task<IEnumerable<Forward>> GetForward(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime oDate, DateTime oDateTo, DateTime valueDate, DateTime valueDateTo, string ccy, string portFolio, string broker, string trader, string customer, int orderBy)
        {
            return _ForwardRepository.GetForward(dealNo, dealNoTo, dealDate, dealDateTo, oDate, oDateTo, valueDate, valueDateTo, ccy, portFolio, broker, trader, customer, orderBy);
        }
    }
}
