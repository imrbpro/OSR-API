using OSR_API.Models;

namespace OSR_API.Repositories.Interface
{
    public interface ISetofffwRepository
    {
        Task<IEnumerable<Setofffw>> GetSetOffFw();
    }
}
