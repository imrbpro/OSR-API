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
    public class CloseoutService : ICloseoutService
    {
        private readonly ICloseoutRepository _closeoutRepository;
        public CloseoutService(ICloseoutRepository closeoutRepository)
        {
            _closeoutRepository = closeoutRepository;
        }

        public Task<IEnumerable<Closeout>> GetCloseouts()
        {
            return _closeoutRepository.GetCloseout();
        }
    }
}
