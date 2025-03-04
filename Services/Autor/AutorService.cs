using WebApi_Livros.Data;
using WebApiLivros.Models;
using Microsoft.EntityFrameworkCore;
using WebApiLivros.Dto.Autor;


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
                // pega AutorModel de dentro da livro model e o id do autor referente ao livro
                var livro = _context.Livros.Include(livro => livro.Autor).FirstOrDefault(livro => livro.Id == idLivro);

                if (livro == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = livro.Autor; // retorna apenas o autor
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
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autor)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autorCriado = new AutorModel()
                {
                    Nome = autor.Nome,
                    Sobrenome = autor.Sobrenome
                };

                _context.Add(autorCriado); // recebe o autor model, nao autor dto
                await _context.SaveChangesAsync();
                response.Mensagem = "Autor criado com sucesso";
                response.Dados = await _context.Autores.ToListAsync();
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> AtualizarAutor(AutorAtualizarDto autor)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autorAtualizado = _context.Autores.FirstOrDefault(autorBanco => autorBanco.Id == autor.Id);

                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }

                autorAtualizado.Nome = autor.Nome;
                autorAtualizado.Sobrenome = autor.Sobrenome;
                await _context.SaveChangesAsync();
                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor atualizado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> DeletarAutor(int id)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor deletado com sucesso";
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
