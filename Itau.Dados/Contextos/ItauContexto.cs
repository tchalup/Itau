using Itau.Dados.Mapeamentos;
using Itau.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Itau.Dados.Contextos
{
    public class ItauContexto : DbContext
    {
        public ItauContexto(DbContextOptions options) : base(options)
        {
        }

        #region DbSet

        public DbSet<ImagemCategoria> ImagensCategoria { get; set; }
        public DbSet<Raca> Racas { get; set; }
        public DbSet<Temperamento> Temperamentos { get; set; }
        public DbSet<Origem> Origens { get; set; }
        public DbSet<RacaTemperamento> TemperamentosRaca { get; set; }

        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImagemCategoriaMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrigemMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RacaMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RacaImagemMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemperamentoMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemperamentoRacaMap).Assembly);
        }
    }
}
