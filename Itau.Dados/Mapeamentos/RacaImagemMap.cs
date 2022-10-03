using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    internal class RacaImagemMap : IEntityTypeConfiguration<RacaImagem>
    {
        public void Configure(EntityTypeBuilder<RacaImagem> builder)
        {
            builder.ToTable("RacaImagem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImagemUrl).HasColumnName("ImagemUrl").HasColumnType("varchar(500)").IsRequired();
            builder.HasOne(x => x.Raca).WithMany(x => x.RacaImagens).HasForeignKey(x => x.RacaId);
        }
    }
}
