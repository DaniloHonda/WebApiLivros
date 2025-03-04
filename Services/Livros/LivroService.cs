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
                var livros = await _context.Livros.Include(autor => autor.Autor).ToListAsync();
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

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int id)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            var livro = await _context.Livros
                .Include(livro => livro.Autor)
                .Where(livro => livro.Autor.Id == id).ToListAsync(); // pode ter varios livros por autor = lista
            if (livro == null)
            {
                response.Mensagem = "Livro não encontrado";
                response.Status = false;
                return response;
            }

            response.Dados = livro;
            response.Mensagem = "Livro encontrado com sucesso";
            return response;
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == livro.Autor.Id);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }

                var livroCriado = new LivroModel()
                {
                    Titulo = livro.Titulo,
                    Autor = autor
                };

                _context.Add(livroCriado);
                await _context.SaveChangesAsync();
                response.Mensagem = "Livro criado com sucesso";
                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> AtualizarLivro(LivroAtualizarDto livro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livroAtualizado = await _context.Livros.Include(autor => autor.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livro.Id); // livro que quer editar

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autor => autor.Id == livro.Autor.Id); // autor que quer editar
                if (livro == null)
                {
                    response.Mensagem = "Livro não encontrado";
                    response.Status = false;
                    return response;
                }
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }

                livroAtualizado.Titulo = livro.Titulo;
                livroAtualizado.Autor = autor;
                await _context.SaveChangesAsync();
                response.Dados = await _context.Livros.ToListAsync();
                response.Mensagem = "Livro atualizado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> DeletarLivro(int id)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(autor => autor.Autor).FirstOrDefaultAsync(livro => livro.Id == id);

                if (livro == null)
                {
                    response.Mensagem = "Livro não encontrado";
                    response.Status = false;
                    return response;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();
                response.Dados = await _context.Livros.ToListAsync();
                response.Mensagem = "Livro deletado com sucesso";
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
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.Include(autor => autor.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == id);
                if (livro == null)
                {
                    response.Mensagem = "Livro(s) não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = livro;
                response.Mensagem = "Livro(s) encontrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

    }
}
