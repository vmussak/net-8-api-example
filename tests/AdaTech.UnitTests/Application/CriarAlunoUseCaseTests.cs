using AdaTech.Application.Repositories;
using AdaTech.Application.Requests;
using AdaTech.Application.UseCases;
using AdaTech.Application.Validators;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.UnitTests.Application
{
    public class CriarAlunoUseCaseTests
    {
        private readonly IValidator<CriarAlunoRequest> _validator;
        private readonly Mock<IAlunoRepository> _alunoRepository;
        private readonly Mock<ICepRepository> _cepRepository;

        public CriarAlunoUseCaseTests()
        {
            _validator = new CriarAlunoValidator();
            _alunoRepository = new Mock<IAlunoRepository>();
            _cepRepository = new Mock<ICepRepository>();
        }

        [Fact]
        public async Task CriarAlunoUseCase_RequestInvalida_DeveRetornar_Success_False()
        {
            var request = new CriarAlunoRequest
            {
                Nome = "",
                Email = "",
                Cep = ""
            };

            var useCase = new CriarAlunoUseCase(_validator, _alunoRepository.Object, _cepRepository.Object);

            var response = await useCase.Handle(request, new CancellationToken());

            Assert.False(response.Success);
            Assert.NotEmpty(response.Messages);
        }

        [Fact]
        public async Task CriarAlunoUseCase_EnderecoNaoEncontrado_DeveRetornar_Success_False()
        {
            var request = new CriarAlunoRequest
            {
                Nome = "Vinicius Mussak",
                Email = "vinicius.mussak@ada.tech",
                Cep = "11111111"
            };

            var useCase = new CriarAlunoUseCase(_validator, _alunoRepository.Object, _cepRepository.Object);

            var response = await useCase.Handle(request, new CancellationToken());

            Assert.False(response.Success);
            Assert.NotEmpty(response.Messages);
        }

        [Fact]
        public async Task CriarAlunoUseCase_NaoMoraEmMG_DeveRetornar_Success_False()
        {
            _cepRepository.Setup(x => x.BuscarEnderecoPorCep(It.IsAny<string>())).ReturnsAsync(new AdaTech.Core.Dtos.CepDto
            {
                Estado = "SP"
            });

            var request = new CriarAlunoRequest
            {
                Nome = "Vinicius Mussak",
                Email = "vinicius.mussak@ada.tech",
                Cep = "11111111"
            };

            var useCase = new CriarAlunoUseCase(_validator, _alunoRepository.Object, _cepRepository.Object);

            var response = await useCase.Handle(request, new CancellationToken());

            Assert.False(response.Success);
            Assert.NotEmpty(response.Messages);
        }

        [Fact]
        public async Task CriarAlunoUseCase_Ok_DeveRetornar_Success_True()
        {
            _cepRepository.Setup(x => x.BuscarEnderecoPorCep(It.IsAny<string>())).ReturnsAsync(new AdaTech.Core.Dtos.CepDto
            {
                Estado = "MG"
            });

            var request = new CriarAlunoRequest
            {
                Nome = "Vinicius Mussak",
                Email = "vinicius.mussak@ada.tech",
                Cep = "11111111"
            };

            var useCase = new CriarAlunoUseCase(_validator, _alunoRepository.Object, _cepRepository.Object);

            var response = await useCase.Handle(request, new CancellationToken());

            Assert.True(response.Success);
            Assert.Null(response.Messages);
        }
    }
}
