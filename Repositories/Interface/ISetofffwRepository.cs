using OSR_API.Models;
using OSR_API.Models.dto;

namespace OSR_API.Repositories.Interface
{
    public interface ISetofffwRepository
    {
        Task<IEnumerable<Setofffw>> GetSetOffFw(SetOffDto setOff);
    }
}
