using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    public class RacaMap : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("Raca");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)").IsRequired();

            builder.HasOne(x => x.Origem);
            builder.HasMany(x => x.RacaImagens);
        }
    }
}
