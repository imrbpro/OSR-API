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
    public class ReadyService : IReadyService
    {
        private readonly IReadyRepository _readyRepository;
        public ReadyService(IReadyRepository readyRepository)
        {
            _readyRepository = readyRepository;
        }
        public Task<IEnumerable<Ready>> GetReady()
        {
            return _readyRepository.GetReady();
        }
    }
}
