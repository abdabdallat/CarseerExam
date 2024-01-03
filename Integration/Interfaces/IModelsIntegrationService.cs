using Integration.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Interfaces
{
    public interface IModelsIntegrationService
    {
        public Task<IntegrationResult<List<ModelsIntegrationResponseDTO>>> GetModelsForMakeIdYear(long makeId, int modelYear);
    }
}
