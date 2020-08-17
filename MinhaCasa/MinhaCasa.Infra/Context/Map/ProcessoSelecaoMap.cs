using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaCasa.Domain.NaoContemplados.Entities;

namespace MinhaCasa.Infra.Context.Map
{
    class ProcessoSelecaoMap : IEntityTypeConfiguration<ProcessosSelecao>
    {
        public void Configure(EntityTypeBuilder<ProcessosSelecao> montar)
        {
            montar.ToTable("ProcessoSelecao");
            montar.HasKey(x => x.Id);
        }
    }
}
