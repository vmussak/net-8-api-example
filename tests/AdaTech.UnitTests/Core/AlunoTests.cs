using AdaTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.UnitTests.Core
{
    public class AlunoTests
    {
        [Fact]
        public void AlunoMoraEmMinasGerais_DeveRetornarTrue()
        {
            // Arrange
            var aluno = new Aluno
            {
                Uf = "MG"
            };

            // Act
            var result = aluno.AlunoMoraEmMinasGerais();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AlunoNaoMoraEmMinasGerais_DeveRetornarFalse()
        {
            // Arrange
            var aluno = new Aluno
            {
                Uf = "SP"
            };

            // Act
            var result = aluno.AlunoMoraEmMinasGerais();

            // Assert
            Assert.False(result);
        }
    }
}
