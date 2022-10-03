namespace Itau.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SalvarAsync();
    }
}
