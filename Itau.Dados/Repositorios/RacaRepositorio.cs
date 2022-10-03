using Itau.Dados.Contextos;
using Itau.Dominio.DTO;
using Itau.Dominio.Entidades;
using Itau.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Itau.Dados.Repositorios
{
    public class RacaRepositorio : BaseRepositorio, IRacaRepositorio
    {
        public RacaRepositorio(ItauContexto contexto) : base(contexto)
        {
        }

        public async Task AddRangeAsync(IEnumerable<Raca> Racas)
            => await _contexto.Racas.AddRangeAsync(Racas);

        public async Task<IEnumerable<RacaResponse>> ListarPorOrigemAsync(int origem)
            => await _contexto.Racas
                              .Select(b => new RacaResponse { Id = b.Id, Nome = b.Nome })
                              .ToListAsync();

        public async Task<IEnumerable<RacaResponse>> ListarPorTemperamentoAsync(int temperamentoId)
            => await _contexto.Racas
                              .Where(x => x.TemperamentoRaca.Any(y => y.TemperamentoId == temperamentoId))
                              .Select(x => new RacaResponse { Id = x.Id, Nome = x.Nome })
                              .ToListAsync();

        public async Task<IEnumerable<RacaResponse>> ListarTodosAsync()
            => await _contexto.Racas
                              .Select(b => new RacaResponse { Id = b.Id, Nome = b.Nome })
                              .ToListAsync();

        public async Task<RacaInformacoesResponse> ObterInformacoesAsync(int racaId)
            => await _contexto.Racas
                              .Select(b => new RacaInformacoesResponse { Id = b.Id, Informacao = b.Descricao })
                              .FirstOrDefaultAsync(b => b.Id == racaId) ?? new RacaInformacoesResponse();
    }
}
