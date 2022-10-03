using Itau.Dominio.Enums;

namespace Itau.Dominio.Entidades
{
    public class ImagemCategoria
    {
        public int Id { get; set; }
        public CategoriaImagem CategoriaImagem { get; set; }
        public string Url { get; set; }
    }
}
