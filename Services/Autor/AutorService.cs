using WebApi_Livros.Data;
using WebApiLivros.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiLivros.Services.Autor
{
    // Controller comunica com interface, interface com o service
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) // a partir de _context temos acesso aos dados do banco
        {
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutor(int id)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == id);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor encontrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = _context.Autores.FirstOrDefault(autorBanco => autorBanco.Livros.Any(livro => livro.Id == idLivro));
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor encontrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync(); // so continua apos esperar o tolist terminar
                response.Dados = autores;
                response.Mensagem = "Autores listados com sucesso";

                return response;
            }
            catch (Exception ex) {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
