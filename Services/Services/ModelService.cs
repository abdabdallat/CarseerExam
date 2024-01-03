using Core.DTOs;
using Infrastructure.Interfaces;
using Integration.Interfaces;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Infrastructure.Services
{
    public class ModelService : IModelsService
    {
        #region Constants
        private readonly IModelsIntegrationService _modelsIntegrationService;
        private readonly IHostEnvironment _env;
        #endregion
        #region Constructor
        public ModelService(IModelsIntegrationService modelsIntegrationService,
            IHostEnvironment env)
        {
            _env = env;
            _modelsIntegrationService = modelsIntegrationService;

        }

        #endregion
        #region Public Methods
        public async Task<List<string>> GetModelsForMakeIdYear(GetModelRequestDTO model)
        {
            var result = new List<string>();
            int makeId = GetMakeIdByMakeName(model.Make?.Trim());
            if (makeId == -1)
            {
                return result;
            }
            var integrationResult = await _modelsIntegrationService.GetModelsForMakeIdYear(makeId, model.ModelYear);
            if (integrationResult != null && integrationResult.Results != null)
            {
                result = integrationResult.Results.DistinctBy(p=>p.ModelName).Select(p => p.ModelName).ToList();
            }
            return result;
        }
        #endregion


        #region Private Methods


        private int GetMakeIdByMakeName(string makeName)
        {
            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/CarMake.csv");

                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header row
                {
                    var values = ParseCsvLine(line);

                    if (values.Length >= 2)
                    {
                        var currentMakeId = int.Parse(values[0]);
                        var currentMakeName = values[1];

                        if (string.Equals(currentMakeName, makeName, StringComparison.OrdinalIgnoreCase))
                        {
                            return currentMakeId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return -1; // default value 
        }
        private string[] ParseCsvLine(string line)
        {
            // Use a simple CSV parser that handles quoted values and commas
            var values = new List<string>();
            var inQuotes = false;
            var currentField = "";

            foreach (var character in line)
            {
                if (character == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (character == ',' && !inQuotes)
                {
                    values.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += character;
                }
            }

            values.Add(currentField);
            return values.ToArray();
        }
        #endregion

    }

}

