using OSR_API.Models;

namespace OSR_API.Services.Interface
{
    public interface IForwardService
    {
        Task<IEnumerable<Forward>> GetForward();
    }
}
