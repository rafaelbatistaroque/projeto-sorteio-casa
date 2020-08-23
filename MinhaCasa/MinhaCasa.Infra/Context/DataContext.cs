using Microsoft.EntityFrameworkCore;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using MinhaCasa.Infra.Context.Map;

namespace MinhaCasa.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<ProcessosSelecao> ProcessosSelecao { get; set; }

        public DataContext(DbContextOptions options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder montarModel)
        {
            montarModel.ApplyConfiguration(new FamiliaMap());
            montarModel.ApplyConfiguration(new ProcessoSelecaoMap());
            montarModel.ApplyConfiguration(new PessoaMap());
            //base.OnModelCreating(montarModel);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opcao)
        {
            //opcao.UseInMemoryDatabase("DBDigixMemory");
            opcao.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=DBDigix;trusted_connection=true;");
        }
    }
}
