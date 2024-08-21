using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICloseoutService
    {
        Task<IEnumerable<Closeout>> GetCloseouts(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy);
    }
}
