using AdaTech.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infrastructure.SqlServer.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");  

            builder.HasKey(a => a.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .HasColumnName("Nome");

            builder.Property(x => x.Cep)
                   .HasMaxLength(10)
                   .HasColumnType("varchar(10)")
                   .HasColumnName("Cep");

            builder.Property(x => x.Rua)
                   .HasMaxLength(200)
                   .HasColumnType("varchar(200)")
                   .HasColumnName("Rua");

            builder.Property(x => x.Bairro)
                   .HasMaxLength(200)
                   .HasColumnType("varchar(200)")
                   .HasColumnName("Bairro");

            builder.Property(x => x.Cidade)
                   .HasMaxLength(200)
                   .HasColumnType("varchar(200)")
                   .HasColumnName("Cidade");

            builder.Property(x => x.Uf)
                   .HasMaxLength(2)
                   .HasColumnType("char(2)")
                   .HasColumnName("Uf");

            builder.Property(x => x.CriadoEm)
                   .IsRequired()
                   .HasColumnName("CriadoEm");
        }
    }
}
