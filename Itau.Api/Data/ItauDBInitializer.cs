using Itau.Dominio.Entidades;
using Itau.Dominio.Interfaces;
using Itau.Dominio.Interfaces.Repositorios;
using Itau.TheCat.Dominio.Enums;
using IRacaRepositorioAPI = Itau.TheCat.Dominio.Interfaces.Repositorios.IRacaRepositorio;
using IRacaRepositorioLocal = Itau.Dominio.Interfaces.Repositorios.IRacaRepositorio;

namespace Itau.Api.Data
{
    public class ItauDBInitializer
    {
        private readonly IRacaRepositorioAPI _racaRepositorioAPI;
        private readonly IImagemCategoriaRepositorio _imagemCategoriaRepositorio;
        private readonly ITemperamentoRepositorio _temperamentoRepositorio;
        private readonly IOrigemRepositorio _origemRepositorio;
        private readonly IRacaRepositorioLocal _racaRepositorioLocal;
        private readonly IUnitOfWork _unitOfWork;

        public ItauDBInitializer(IRacaRepositorioAPI racaRepositorioAPI
                               , IImagemCategoriaRepositorio imagemCategoriaRepositorio
                               , ITemperamentoRepositorio temperamentoRepositorio
                               , IOrigemRepositorio origemRepositorio
                               , IRacaRepositorioLocal racaRepositorioLocal
                               , IUnitOfWork unitOfWork)
        {
            _racaRepositorioAPI = racaRepositorioAPI;
            _imagemCategoriaRepositorio = imagemCategoriaRepositorio;
            _temperamentoRepositorio = temperamentoRepositorio;
            _origemRepositorio = origemRepositorio;
            _racaRepositorioLocal = racaRepositorioLocal;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Seed()
        {
            var todos = await _racaRepositorioAPI.ListarTodosAsync();

            var imagensLocal = await ImagensCategoria();
            await _imagemCategoriaRepositorio.AddRangeAsync(imagensLocal);

            var temperamento = Temperamentos(todos);
            await _temperamentoRepositorio.AddRangeAsync(temperamento);

            var origens = Origens(todos);
            await _origemRepositorio.AddRangeAsync(origens);

            var racas = Racas(todos, origens, temperamento);
            await RacaImagem(todos, racas);
            await _racaRepositorioLocal.AddRangeAsync(racas);

            return await _unitOfWork.SalvarAsync();
        }

        private async Task<IEnumerable<ImagemCategoria>> ImagensCategoria()
        {
            var resultado = new List<ImagemCategoria>();

            foreach (var categoria in Enum.GetValues(typeof(CategoriaImagem)))
            {
                var imagensLocal = await _racaRepositorioAPI.ListarPorCategoriaIdAsync((CategoriaImagem)categoria, 3);
                var imagensCategoria = imagensLocal.Select(x => new ImagemCategoria { CategoriaImagem = (Dominio.Enums.CategoriaImagem)categoria, Url = x.Url }).ToList();
                resultado.AddRange(imagensCategoria);
            }

            return resultado;
        }

        private IEnumerable<Temperamento> Temperamentos(IEnumerable<TheCat.Dominio.Entidades.Raca> racas)
        {
            var temperamentos = racas.SelectMany(x => x.Temperaments)
                         .Select(t => t)
                         .Distinct()
                         .Select(y => new Temperamento { Nome = y })
                         .ToList();

            return temperamentos;
        }

        private IEnumerable<Origem> Origens(IEnumerable<TheCat.Dominio.Entidades.Raca> racas)
        {
            var origens = racas.Select(x => new { Key = x.Country_code, Name = x.Origin })
                               .Distinct()
                               .Select(x => new Origem { Chave = x.Key, Nome = x.Name })
                               .ToList();

            return origens;
        }

        private IEnumerable<Raca> Racas(IEnumerable<TheCat.Dominio.Entidades.Raca> racas
                                                      , IEnumerable<Origem> origens
                                                      , IEnumerable<Temperamento> temperamentos)
        {
            var result = racas.Select(x => new { x.Name, x.Description, x.Origin, x.Temperament, x.Temperaments })
                             .Distinct()
                             .Select(x =>
                             {
                                 var origem = origens.FirstOrDefault(y => y.Nome == x.Origin);

                                 var raca = new Raca
                                 {
                                     Nome = x.Name,
                                     Descricao = x.Description,
                                     OrigemId = origem.Id,
                                     Origem = origem
                                 };

                                 raca.TemperamentoRaca = temperamentos.Where(z => x.Temperaments.Contains(z.Nome))
                                                                      .Select(temperamento => new RacaTemperamento { Raca = raca, Temperamento = temperamento })
                                                                      .ToList();

                                 return raca;
                             }).ToList();

            return result;
        }

        private async Task RacaImagem(IEnumerable<TheCat.Dominio.Entidades.Raca> racasApi, IEnumerable<Raca> racasLocal)
        {
            foreach (var raca in racasApi)
            {
                var racaLocal = racasLocal.Single(x => x.Nome.ToLower().Equals(raca.Name.ToLower()));
                var racaImagensApi = await _racaRepositorioAPI.ListarPorRacaIdAsync(raca.Id, 3);
                var racaImagensLocal = racaImagensApi.Select(x => new RacaImagem { RacaId = racaLocal.Id, Raca = racaLocal, ImagemUrl = x.Url }).ToList();
                racaLocal.RacaImagens.AddRange(racaImagensLocal);
            }
        }

    }
}
