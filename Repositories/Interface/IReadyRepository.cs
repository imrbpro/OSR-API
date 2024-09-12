using Models;
using Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IReadyRepository
    {
        Task<IEnumerable<Ready>> GetReady(ReadyDto ready);
    }
}
