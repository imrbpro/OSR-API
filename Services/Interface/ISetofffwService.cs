using OSR_API.Models;

namespace OSR_API.Services.Interface
{
    public interface ISetofffwService
    {
        Task<IEnumerable<Setofffw>> GetSetofffw(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portfolio, string trad, string customer, int orderBy);
    }
}
