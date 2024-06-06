using OSR_API.Models;

namespace OSR_API.Repositories.Interface
{
    public interface IForwardRepository
    {
        Task<IEnumerable<Forward>> GetForward();
    }
}
