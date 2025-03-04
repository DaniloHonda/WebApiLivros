using Microsoft.AspNetCore.Mvc;
using WebApiLivros.Dto.Livro;
using WebApiLivros.Models;
using WebApiLivros.Services.Livros;

namespace WebApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController:ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            if (livros.Status)
            {
                return Ok(livros);
            }
            return BadRequest(livros);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivro(int id)
        {
            var livro = await _livroInterface.BuscarLivro(id);
            if (livro.Status)
            {
                return Ok(livro);
            }
            return BadRequest(livro);
        }

        [HttpGet("BuscarLivroPorAutorId")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivroPorIdAutor(int id)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(id);
            if (livro.Status)
            {
                return Ok(livro);
            }
            return BadRequest(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livro)
        {
            var livroCriado = await _livroInterface.CriarLivro(livro);
            if (livroCriado.Status)
            {
                return Ok(livroCriado);
            }
            return BadRequest(livroCriado);
        }

        [HttpPut("AtualizarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> AtualizarLivro(LivroAtualizarDto livro)
        {
            var livroAtualizado = await _livroInterface.AtualizarLivro(livro);
            if (livroAtualizado.Status)
            {
                return Ok(livroAtualizado);
            }
            return BadRequest(livroAtualizado);
        }

        [HttpDelete("DeletarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeletarLivro(int id)
        {
            var livro = await _livroInterface.DeletarLivro(id);
            if(livro.Status)
            {  
                return Ok(livro);
            }
            return BadRequest(livro);
        }
    }
}
