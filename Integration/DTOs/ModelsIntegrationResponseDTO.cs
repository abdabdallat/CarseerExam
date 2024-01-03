using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Integration.DTOs
{
    public class ModelsIntegrationResponseDTO
    {
        [JsonPropertyName("MAKE_ID")]
        public long MakeId { get; set; }
        [JsonPropertyName("MAKE_NAME")]
        public string MakeName { get; set; }
        [JsonPropertyName("MODEL_ID")]
        public long ModelId { get; set; }
        [JsonPropertyName("Model_Name")]
        public string ModelName { get; set; }

    }
}
