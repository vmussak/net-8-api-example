using AdaTech.Application.Presenters;
using AdaTech.Application.Repositories;
using AdaTech.Application.Requests;
using AdaTech.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.UseCases
{
    public class BuscarAlunosUseCase : IRequestHandler<BuscarTodosAlunosRequest, DefaultResponse<IEnumerable<Aluno>>>
    {
        private readonly IAlunoRepository _alunoRepository;

        public BuscarAlunosUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<DefaultResponse<IEnumerable<Aluno>>> Handle(BuscarTodosAlunosRequest request, CancellationToken cancellationToken)
        {
            var alunos = await _alunoRepository.BuscarTodos();

            return new DefaultResponse<IEnumerable<Aluno>>(alunos);
        }
    }
}
