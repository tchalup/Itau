using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.Dados.Mapeamentos
{
    public class ImagemCategoriaMap : IEntityTypeConfiguration<ImagemCategoria>
    {
        public void Configure(EntityTypeBuilder<ImagemCategoria> builder)
        {
            builder.ToTable("ImagemCategoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoriaImagem).HasColumnName("CategoriaImagem").HasColumnType("INT").IsRequired();
            builder.Property(x => x.Url).HasColumnName("Url").HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}
