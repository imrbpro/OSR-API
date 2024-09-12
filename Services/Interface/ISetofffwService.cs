using OSR_API.Models;
using OSR_API.Models.dto;

namespace OSR_API.Services.Interface
{
    public interface ISetofffwService
    {
        Task<IEnumerable<Setofffw>> GetSetofffw(SetOffDto setOff);
    }
}
