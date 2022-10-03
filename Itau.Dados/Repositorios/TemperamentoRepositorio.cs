using Itau.Dados.Contextos;
using Itau.Dominio.Entidades;
using Itau.Dominio.Interfaces.Repositorios;

namespace Itau.Dados.Repositorios
{
    public class TemperamentoRepositorio : BaseRepositorio, ITemperamentoRepositorio
    {
        public TemperamentoRepositorio(ItauContexto contexto) : base(contexto)
        {
        }

        public async Task AddRangeAsync(IEnumerable<Temperamento> Temperamentos)
            => await _contexto.Temperamentos.AddRangeAsync(Temperamentos);
    }
}
