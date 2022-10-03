using Itau.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;

namespace Itau.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RacaController : ControllerBase
    {
        private readonly IRacaRepositorio _racaRepositorio;

        public RacaController(IRacaRepositorio racaRepositorio)
            => _racaRepositorio = racaRepositorio;

        [HttpGet("")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                Log.Information("Chamada --> Raca/ListarTodos");
                return Ok(await _racaRepositorio.ListarTodosAsync());
            }
            catch (Exception ex)
            {
                Log.Fatal($"Falha ao iniciar {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }

        [HttpGet("{racaId}/informecoes")]
        public async Task<IActionResult> ObterInformacoes(int racaId)
        {
            try
            {
                Log.Information("Chamada --> Raca/ObterInformacoes");
                return Ok(await _racaRepositorio.ObterInformacoesAsync(racaId));
            }
            catch (Exception ex)
            {
                Log.Fatal($"Falha ao iniciar {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }

        [HttpGet("temperamento/{temperamentoId}")]
        public async Task<IActionResult> ListarPorTemperamento(int temperamentoId)
        {
            try
            {
                Log.Information("Chamada --> Raca/ListarPorTemperamento");
                return Ok(await _racaRepositorio.ListarPorTemperamentoAsync(temperamentoId));
            }
            catch (Exception ex)
            {
                Log.Fatal($"Falha ao iniciar {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }

        [HttpGet("origem/{origem}")]
        public async Task<IActionResult> ListarPorOrigem(int origem)
        {
            try
            {
                Log.Information("Chamada --> Raca/ListarPorOrigem");
                return new JsonResult(await _racaRepositorio.ListarPorOrigemAsync(origem));
            }
            catch (Exception ex)
            {
                Log.Fatal($"Falha ao iniciar {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }
    }
}
