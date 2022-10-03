using Itau.Dados.Contextos;
using Itau.Dominio.Entidades;
using Itau.Dominio.Interfaces.Repositorios;

namespace Itau.Dados.Repositorios
{
    public class ImagemCategoriaRepositorio : BaseRepositorio, IImagemCategoriaRepositorio
    {
        public ImagemCategoriaRepositorio(ItauContexto contexto) : base(contexto)
        {
        }

        public async Task AddRangeAsync(IEnumerable<ImagemCategoria> imagensCategoria)
            => await _contexto.ImagensCategoria.AddRangeAsync(imagensCategoria);
    }
}
