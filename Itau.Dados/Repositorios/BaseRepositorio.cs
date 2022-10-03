using Itau.Dados.Contextos;

namespace Itau.Dados.Repositorios
{
    public abstract class BaseRepositorio
    {
        protected ItauContexto _contexto;

        protected BaseRepositorio(ItauContexto contexto)
            => _contexto = contexto;
    }
}
