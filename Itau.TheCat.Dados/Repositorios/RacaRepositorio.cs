using Itau.TheCat.Dados.Config;
using Itau.TheCat.Dominio.Entidades;
using Itau.TheCat.Dominio.Enums;
using Itau.TheCat.Dominio.Interfaces.Repositorios;
using System.Net.Http.Json;

namespace Itau.TheCat.Dados.Repositorios
{
    public class RacaRepositorio : IRacaRepositorio
    {
        private readonly TheCatConfig _theCatConfig;

        public RacaRepositorio(TheCatConfig theCatConfig)
            => _theCatConfig = theCatConfig;

        public async Task<IEnumerable<RacaImagem>> ListarPorRacaIdAsync(string racaId, int limite)
        {
            using var client = new BaseHttpClient(_theCatConfig.URI);
            var result = await client.GetFromJsonAsync<IEnumerable<RacaImagem>>($"v1/images/search?breed_ids={racaId}&limit={limite}");

            return result ?? new List<RacaImagem>();
        }

        public async Task<IEnumerable<RacaImagem>> ListarPorCategoriaIdAsync(CategoriaImagem categoriaId, int limite)
        {
            using var client = new BaseHttpClient(_theCatConfig.URI);
            var result = await client.GetFromJsonAsync<IEnumerable<RacaImagem>>($"v1/images/search?category_ids={(int)categoriaId}&limit={limite}");

            return result ?? new List<RacaImagem>();
        }

        public async Task<IEnumerable<Raca>> ListarTodosAsync()
        {
            using var client = new BaseHttpClient(_theCatConfig.URI);
            var result = await client.GetFromJsonAsync<IEnumerable<Raca>>($"v1/breeds");

            return result ?? new List<Raca>();
        }
    }
}
