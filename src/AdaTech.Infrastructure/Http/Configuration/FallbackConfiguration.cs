using Polly.Fallback;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdaTech.Core.Dtos;

namespace AdaTech.Infrastructure.Http.Configuration
{
    public static class FallbackConfiguration
    {
        public static AsyncFallbackPolicy<CepDto> CreateFallbackPolicy()
        {
            return Policy<CepDto>
                .Handle<Exception>()
                .FallbackAsync<CepDto>(
                    fallbackAction: (_, _) =>
                    {
                        Console.Out.WriteLineAsync();
                        Console.Out.WriteLineAsync();

                        return Task.FromResult(new CepDto()
                        {
                            Estado = "MG",
                            Bairro = "São José",
                            Cidade = "Belo Horizonte",
                            Rua = "Rua das Flores"
                        });
                    },
                    onFallbackAsync: (responseToFailedRequest, _) =>
                    {
                        Console.Out.WriteLineAsync();
                        return Task.CompletedTask;
                    });
        }
    }
}
