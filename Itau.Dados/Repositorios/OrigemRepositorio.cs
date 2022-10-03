using Itau.Dados.Contextos;
using Itau.Dominio.Entidades;
using Itau.Dominio.Interfaces.Repositorios;

namespace Itau.Dados.Repositorios
{
    public class OrigemRepositorio : BaseRepositorio, IOrigemRepositorio
    {
        public OrigemRepositorio(ItauContexto contexto) : base(contexto)
        {
        }

        public async Task AddRangeAsync(IEnumerable<Origem> Origens)
            => await _contexto.Origens.AddRangeAsync(Origens);
    }
}
