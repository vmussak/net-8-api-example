using AdaTech.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Repositories
{
    public interface ICepRepository
    {
        Task<CepDto> BuscarEnderecoPorCep(string cep);
    }
}
