using AdaTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Presenters
{
    public class AlunoPresenter
    {
        public static AlunoPresenter AdaptToPresenter(Aluno aluno)
        {
            return new AlunoPresenter
            {
                Nome = aluno.Nome,
                Email = aluno.Email,
                Uf = aluno.Uf,
                Bairro = aluno.Bairro
            };
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Uf { get; set; }
        public string Bairro { get; set; }
    }
}
