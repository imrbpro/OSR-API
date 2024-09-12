using OSR_API.Models;
using OSR_API.Models.dto;

namespace OSR_API.Services.Interface
{
    public interface IForwardService
    {
        Task<IEnumerable<Forward>> GetForward(ForwardDto forward);
    }
}
