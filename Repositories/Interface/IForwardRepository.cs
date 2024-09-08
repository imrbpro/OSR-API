using OSR_API.Models;

namespace OSR_API.Repositories.Interface
{
    public interface IForwardRepository
    {
        Task<IEnumerable<Forward>> GetForward(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime oDate, DateTime oDateTo, DateTime valueDate, DateTime valueDateTo, string ccy, string portFolio, string broker, string trader, string customer, int orderBy);
    }
}
