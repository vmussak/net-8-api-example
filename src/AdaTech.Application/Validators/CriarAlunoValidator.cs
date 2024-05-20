using AdaTech.Application.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Validators
{
    public class CriarAlunoValidator : AbstractValidator<CriarAlunoRequest>
    {
        public CriarAlunoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório")
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("CEP é obrigatório")
                .Length(8)
                .WithMessage("CEP inválido");
        }
    }
}
