using OSR_API.Models;
using OSR_API.Models.dto;
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

        public Task<IEnumerable<Forward>> GetForward(ForwardDto forward)
        {
            return _ForwardRepository.GetForward(forward);
        }
    }
}
