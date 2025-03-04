using WebApiLivros.Models;
using WebApiLivros.Dto.Livro;

namespace WebApiLivros.Services.Livros
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivro(int id);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int id);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livro);
        Task<ResponseModel<List<LivroModel>>> AtualizarLivro(LivroAtualizarDto livro);
        Task<ResponseModel<List<LivroModel>>> DeletarLivro(int id);
    }
}
