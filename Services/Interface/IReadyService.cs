using Models;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IReadyService
    {
        Task<IEnumerable<Ready>> GetReady(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string trader, string customer, char ps, int orderBy);
    }
}
