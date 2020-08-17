using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaCasa.Domain.NaoContemplados.Entities;

namespace MinhaCasa.Infra.Context.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> montar)
        {
            montar.ToTable("Pessoa");
            montar.HasKey(x => x.Id);
            montar.HasIndex(x => x.Id);
            montar.Property(x => x.Nome).IsRequired().HasColumnType("varchar(60)");
            montar.Property(x => x.DataNascimento).IsRequired();
            montar.Property(x => x.TipoVinculoFamiliar).IsRequired().HasColumnType("SMALLINT");
            montar.OwnsOne(x => x.Renda,
                r =>
                {
                    r.Property(r => r.Valor).HasColumnName("ValorRenda").HasColumnType("decimal(18,2)");
                });
        }
    }
}
