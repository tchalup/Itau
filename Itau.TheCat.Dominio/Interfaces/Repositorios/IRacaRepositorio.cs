using Itau.TheCat.Dominio.Entidades;
using Itau.TheCat.Dominio.Enums;

namespace Itau.TheCat.Dominio.Interfaces.Repositorios
{
    public interface IRacaRepositorio
    {
        Task<IEnumerable<Raca>> ListarTodosAsync();
        Task<IEnumerable<RacaImagem>> ListarPorRacaIdAsync(string racaId, int limite);
        Task<IEnumerable<RacaImagem>> ListarPorCategoriaIdAsync(CategoriaImagem categoriaId, int limite);
    }
}
