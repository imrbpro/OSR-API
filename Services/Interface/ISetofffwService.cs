using OSR_API.Models;

namespace OSR_API.Services.Interface
{
    public interface ISetofffwService
    {
        Task<IEnumerable<Setofffw>> GetSetofffw();
    }
}
