using ProjetoCrud.Dto.Vinculo;
using ProjetoCrud.Model;
using System.Text.Json.Serialization;

namespace ProjetoCrud.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
