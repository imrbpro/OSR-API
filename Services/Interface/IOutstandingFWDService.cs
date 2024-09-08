using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOutstandingFWDService
    {
        Task<IEnumerable<OutstandingFWD>> GetOutstandingFWD(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portFolio, string branchcode, string trader, string customer, int orderBy);
    }
}
