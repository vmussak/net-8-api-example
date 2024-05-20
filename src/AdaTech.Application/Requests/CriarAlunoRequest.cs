using AdaTech.Application.Presenters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Requests
{
    public class CriarAlunoRequest : IRequest<DefaultResponse<AlunoPresenter>>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
    }
}
