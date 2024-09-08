using Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OutstandingFWDService : IOutstandingFWDService
    {
        public readonly IOutstandingFWDRepository _outstandingFWDRepository;
        public OutstandingFWDService(IOutstandingFWDRepository outstandingFWDRepository) 
        { 
            _outstandingFWDRepository = outstandingFWDRepository;
        }
        public Task<IEnumerable<OutstandingFWD>> GetOutstandingFWD(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portFolio, string branchcode, string trader, string customer, int orderBy)
        {
            return _outstandingFWDRepository.GetOuttandingFWD(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portFolio, branchcode, trader, customer, orderBy);
        }
    }
}
