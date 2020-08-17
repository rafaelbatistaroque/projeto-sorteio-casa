using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaCasa.Domain.NaoContemplados.Entities;

namespace MinhaCasa.Infra.Context.Map
{
    public class FamiliaMap : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> montar)
        {
            montar.ToTable("Familia");

            montar.HasKey(x => x.Id);
            montar.Property(x => x.Pontuacao).HasMaxLength(2).HasDefaultValue(0);
            montar.Property(x => x.QuantidadeCriteriosAtendidos).HasDefaultValue(0).HasColumnType("SMALLINT");
            montar.Property(x => x.CategoriaDependente).HasColumnType("SMALLINT");
            montar.Property(x => x.CategoriaIdadePretendente).HasColumnType("SMALLINT");
            montar.Property(x => x.CategoriaRenda).HasColumnType("SMALLINT");

            montar.HasMany(x => x.Pessoas).WithOne(p => p.Familia).HasForeignKey(p => p.FamiliaId);
            montar.HasMany(x => x.ProcessosSelecao).WithOne(p => p.Familia).HasForeignKey(p => p.FamiliaId);
        }
    }
}
