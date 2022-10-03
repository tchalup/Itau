using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    public class TemperamentoMap : IEntityTypeConfiguration<Temperamento>
    {
        public void Configure(EntityTypeBuilder<Temperamento> builder)
        {
            builder.ToTable("Temperamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
        }
    }
}
