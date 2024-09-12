using Models;
using OSR_API.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICloseoutService
    {
        Task<IEnumerable<Closeout>> GetCloseouts(CloseoutDto closeout);
    }
}
