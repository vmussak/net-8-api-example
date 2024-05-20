using AdaTech.Application.Presenters;
using AdaTech.Application.Repositories;
using AdaTech.Application.Requests;
using AdaTech.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.UseCases
{
    public class CriarAlunoUseCase : IRequestHandler<CriarAlunoRequest, DefaultResponse<AlunoPresenter>>
    {
        private readonly IValidator<CriarAlunoRequest> _validator;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICepRepository _cepRepository;

        public CriarAlunoUseCase(IValidator<CriarAlunoRequest> validator, IAlunoRepository alunoRepository, ICepRepository cepRepository)
        {
            _validator = validator;
            _alunoRepository = alunoRepository;
            _cepRepository = cepRepository;
        }

        public async Task<DefaultResponse<AlunoPresenter>> Handle(CriarAlunoRequest request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                return new DefaultResponse<AlunoPresenter>(validation.Errors.Select(x => x.ErrorMessage));
            }

            var endereco = await _cepRepository.BuscarEnderecoPorCep(request.Cep);

            if (endereco == null)
            {
                return new DefaultResponse<AlunoPresenter>("Endereço não encontrado");
            }

            var aluno = new Aluno
            {
                Nome = request.Nome,
                Email = request.Email,
                Cep = request.Cep,
                Uf = endereco.Estado,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Rua = endereco.Rua,
                CriadoEm = DateTime.Now
            };

            if (!aluno.AlunoMoraEmMinasGerais())
            {
                return new DefaultResponse<AlunoPresenter>("Aluno não mora em Minas Gerais");
            }

            await _alunoRepository.Criar(aluno);

            return new DefaultResponse<AlunoPresenter>(AlunoPresenter.AdaptToPresenter(aluno));
        }
    }
}
