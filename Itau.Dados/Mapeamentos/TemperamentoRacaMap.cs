using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    public class TemperamentoRacaMap : IEntityTypeConfiguration<RacaTemperamento>
    {
        public void Configure(EntityTypeBuilder<RacaTemperamento> builder)
        {
            builder.ToTable("TemperamentoRaca");
            builder.HasKey(x => new { x.RacaId, x.TemperamentoId });
            builder.HasOne(x => x.Raca).WithMany(x => x.TemperamentoRaca).HasForeignKey(x => x.RacaId);
            builder.HasOne(x => x.Temperamento).WithMany(x => x.TemperamentoRaca).HasForeignKey(x => x.TemperamentoId);
        }
    }
}
