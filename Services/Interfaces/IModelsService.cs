using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IModelsService
    {
        public Task<List<string>> GetModelsForMakeIdYear(GetModelRequestDTO model);

    }
}
