using AdaTech.Application.Presenters;
using AdaTech.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Requests
{
    public class BuscarTodosAlunosRequest : IRequest<DefaultResponse<IEnumerable<Aluno>>>
    {
    }
}
