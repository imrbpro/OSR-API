using Models;
using OSR_API.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IOutstandingFWDRepository
    {
        Task<IEnumerable<OutstandingFWD>> GetOuttandingFWD(OutstandingDto outstanding);
    }
}
