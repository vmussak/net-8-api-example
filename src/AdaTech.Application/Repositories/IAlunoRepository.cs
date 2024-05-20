using AdaTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Repositories
{
    public interface IAlunoRepository
    {
        Task<Aluno> Criar(Aluno aluno);

        Task<IEnumerable<Aluno>> BuscarTodos();
    }
}
