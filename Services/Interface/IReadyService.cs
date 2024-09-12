using Models;
using Models.dto;
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
        Task<IEnumerable<Ready>> GetReady(ReadyDto ready);
    }
}
