using WebApi_Livros.Data;
using WebApiLivros.Models;
using Microsoft.EntityFrameworkCore;
using WebApiLivros.Dto.Livro;

namespace WebApiLivros.Services.Livros
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.ToListAsync();
                response.Dados = livros;
                response.Mensagem = "Livros listados com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> AtualizarLivro(LivroAtualizarDto livro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> DeletarLivro(int id)
        {
            throw new NotImplementedException();
        }

    }
}
