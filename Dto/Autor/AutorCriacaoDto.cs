namespace WebApiLivros.Dto.Autor
{
    // model para que na criacao de autor seja necessario apenas nome e sobrenome
    public class AutorCriacaoDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
