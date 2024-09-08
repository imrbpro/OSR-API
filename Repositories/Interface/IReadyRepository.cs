using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IReadyRepository
    {
        Task<IEnumerable<Ready>> GetReady(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string trader, string customer, char ps, int orderBy);
    }
}
