using WebApiLivros.Models;

namespace WebApiLivros.Services.Autor
{
    // Controller comunica com interface, interface com o service
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutor(int id);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
    }
}
