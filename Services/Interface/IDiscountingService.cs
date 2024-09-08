using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IDiscountingService
    {
        Task<IEnumerable<Discounting>> GetDiscounting(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string broker, string trader, string customer, char ps, int orderBy);
    }
}
