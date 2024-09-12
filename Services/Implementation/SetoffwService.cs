using OSR_API.Models;
using OSR_API.Models.dto;
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

        public Task<IEnumerable<Setofffw>> GetSetofffw(SetOffDto setOff)
        {
            return _SetofffwRepository.GetSetOffFw(setOff);
        }
    }
}
