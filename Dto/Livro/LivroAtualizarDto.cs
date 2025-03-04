using WebApiLivros.Dto.Vinculo;

namespace WebApiLivros.Dto.Livro
{
    public class LivroAtualizarDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
