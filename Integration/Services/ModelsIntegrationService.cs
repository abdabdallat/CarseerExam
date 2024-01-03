using Integration.DTOs;
using Integration.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Integration.Services
{
    public class ModelsIntegrationService : IModelsIntegrationService
    {
        const string FormatParameter = "format=Json";
        private readonly IConfiguration _configuration;
        public ModelsIntegrationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IntegrationResult<List<ModelsIntegrationResponseDTO>>> GetModelsForMakeIdYear(long makeId, int modelYear)
        {
            var result = new IntegrationResult<List<ModelsIntegrationResponseDTO>>();
            var apiBaseUrl = _configuration["ModelsIntegrationURL"];

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var apiUrl = $"{apiBaseUrl}/makeId/{makeId}/modelyear/{modelYear}?{FormatParameter}";
                    result = await httpClient.GetFromJsonAsync<IntegrationResult<List<ModelsIntegrationResponseDTO>>>(apiUrl);
                }
            }
            catch (Exception ex)
            {

            }
            return result;

        }
    }
}
