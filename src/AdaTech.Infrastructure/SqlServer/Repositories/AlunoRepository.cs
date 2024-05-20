using AdaTech.Application.Repositories;
using AdaTech.Core.Entities;
using AdaTech.Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infrastructure.SqlServer.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AdaTechContext _context;

        public AlunoRepository(AdaTechContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> BuscarTodos()
        {
            var alunos = await _context.Alunos.ToListAsync();

            return alunos;
        }

        public async Task<Aluno> Criar(Aluno aluno)
        {
            _context.Add(aluno);

            await _context.SaveChangesAsync();

            return aluno;
        }
    }
}
