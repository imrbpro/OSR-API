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
        public Task<IEnumerable<OutstandingFWD>> GetOutstandingFWD()
        {
            return _outstandingFWDRepository.GetOuttandingFWD();
        }
    }
}
