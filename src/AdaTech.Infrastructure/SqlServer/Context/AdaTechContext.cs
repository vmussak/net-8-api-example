using AdaTech.Core.Entities;
using AdaTech.Infrastructure.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infrastructure.SqlServer.Context
{
    public class AdaTechContext : DbContext
    {
        public AdaTechContext(DbContextOptions<AdaTechContext> option) : base(option)
        {
                
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(options =>
            {
                options.CommandTimeout(60);
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                options.MigrationsAssembly("AdaTech.Api");
            });

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors();
        }
    }
}
