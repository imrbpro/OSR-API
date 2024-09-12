using Models;
using OSR_API.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICloseoutRepository
    {
        Task<IEnumerable<Closeout>> GetCloseout(CloseoutDto closeout);
    }
}
