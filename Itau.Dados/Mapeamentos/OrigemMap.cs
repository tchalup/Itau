using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    public class OrigemMap : IEntityTypeConfiguration<Origem>
    {
        public void Configure(EntityTypeBuilder<Origem> builder)
        {
            builder.ToTable("Origem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Chave).HasColumnName("Chave").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
        }
    }
}
