using Itau.Dados.Contextos;
using Itau.Dominio.Interfaces;

namespace Itau.Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItauContexto _itauContexto;

        public UnitOfWork(ItauContexto itauContexto)
            => _itauContexto = itauContexto;

        public async Task<int> SalvarAsync()
            => await _itauContexto.SaveChangesAsync();
    }
}
