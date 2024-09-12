using OSR_API.Models;
using OSR_API.Models.dto;

namespace OSR_API.Repositories.Interface
{
    public interface IForwardRepository
    {
        Task<IEnumerable<Forward>> GetForward(ForwardDto forward);
    }
}
