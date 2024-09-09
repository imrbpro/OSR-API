using OSR_API.Models;

namespace OSR_API.Repositories.Interface
{
    public interface ISetofffwRepository
    {
        Task<IEnumerable<Setofffw>> GetSetOffFw(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portfolio, string trad, string customer, int orderBy);
    }
}
