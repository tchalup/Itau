using Itau.Dominio.Entidades;

namespace Itau.Dominio.Interfaces.Repositorios
{
    public interface IOrigemRepositorio
    {
        Task AddRangeAsync(IEnumerable<Origem> Origens);
    }
}
