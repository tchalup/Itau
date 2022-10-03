using Itau.Dominio.DTO;
using Itau.Dominio.Entidades;

namespace Itau.Dominio.Interfaces.Repositorios
{
    public interface IRacaRepositorio
    {
        Task AddRangeAsync(IEnumerable<Raca> Racas);
        Task<IEnumerable<RacaResponse>> ListarTodosAsync();
        Task<RacaInformacoesResponse> ObterInformacoesAsync(int racaId);
        Task<IEnumerable<RacaResponse>> ListarPorTemperamentoAsync(int temperamentoId);
        Task<IEnumerable<RacaResponse>> ListarPorOrigemAsync(int origem);
    }
}
