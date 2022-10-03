using Itau.Dominio.Entidades;

namespace Itau.Dominio.Interfaces.Repositorios
{
    public interface IImagemCategoriaRepositorio
    {
        Task AddRangeAsync(IEnumerable<ImagemCategoria> imagensCategoria);
    }
}
