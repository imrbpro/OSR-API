using OSR_API.Models;
using OSR_API.Repositories.Interface;
using OSR_API.Services.Interface;

namespace OSR_API.Services.Implementation
{
    public class SetoffwService : ISetofffwService
    {
        private readonly ISetofffwRepository _SetofffwRepository;
        public SetoffwService(ISetofffwRepository SetofffwRepository)
        {
            _SetofffwRepository = SetofffwRepository;
        }

        public Task<IEnumerable<Setofffw>> GetSetofffw(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portfolio, string trad, string customer, int orderBy)
        {
            return _SetofffwRepository.GetSetOffFw(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portfolio, trad, customer, orderBy);
        }
    }
}
