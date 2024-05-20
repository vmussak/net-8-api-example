using AdaTech.Application.Repositories;
using AdaTech.Core.Dtos;
using AdaTech.Infrastructure.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infrastructure.Http
{
    public class CepRepository : ICepRepository
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncCircuitBreakerPolicy _policy;

        public CepRepository(HttpClient httpClient, IConfiguration configuration, AsyncCircuitBreakerPolicy policy)
        {
            _httpClient = httpClient;
            var externalServices = configuration.GetSection("ExternalServices");
            _httpClient.BaseAddress = new Uri(externalServices["CepApiUrl"]);
            _policy = policy;
        }

        public async Task<CepDto> BuscarEnderecoPorCep(string cep)
        {
            var policy = FallbackConfiguration.CreateFallbackPolicy();

            var policyResponse = await policy.ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetAsync(cep);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<CepDto>();
                    return content;
                }

                throw new Exception("Status code não foi de sucesso!!!");
            });

            return policyResponse;
        }
    }
}
