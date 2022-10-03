using Itau.Dominio.Entidades;

namespace Itau.Dominio.Interfaces.Repositorios
{
    public interface ITemperamentoRepositorio
    {
        Task AddRangeAsync(IEnumerable<Temperamento> Temperamentos);
    }
}
