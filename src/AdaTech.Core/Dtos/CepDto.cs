using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdaTech.Core.Dtos
{
    public class CepDto
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("state")]
        public string Estado { get; set; }

        [JsonPropertyName("city")]
        public string Cidade { get; set; }

        [JsonPropertyName("neighborhood")]
        public string Bairro { get; set; }

        [JsonPropertyName("street")]
        public string Rua { get; set; }
    }
}
