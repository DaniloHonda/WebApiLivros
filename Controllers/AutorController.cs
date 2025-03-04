using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLivros.Dto.Autor;
using WebApiLivros.Models;
using WebApiLivros.Services.Autor;

// Controller comunica com interface, interface com o service
namespace WebApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface; // pelo _autorInterface temos acesso aos metodos do service
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        } // construtor que recebe a interface

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            if (autores.Status)
            {
                return Ok(autores);
            }
            return BadRequest(autores);
        }

        [HttpGet("BuscarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutor(int id)
        {
            var autor = await _autorInterface.BuscarAutor(id);
            if (autor.Status)
            {
                return Ok(autor);
            }
            return BadRequest(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            if (autor.Status)
            {
                return Ok(autor);
            }
            return BadRequest(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autor)
        {
            var autorCriado = await _autorInterface.CriarAutor(autor);
            if (autorCriado.Status)
            {
                return Ok(autorCriado);
            }
            return BadRequest(autorCriado);
        }

        [HttpPut("AtualizarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> AtualizarAutor(AutorAtualizarDto autor)
        {
            var autorAtualizado = await _autorInterface.AtualizarAutor(autor);
            if (autorAtualizado.Status)
            {
                return Ok(autorAtualizado);
            }
            return BadRequest(autorAtualizado);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> DeletarAutor(int id)
        {
            var autorDeletado = await _autorInterface.DeletarAutor(id);
            if (autorDeletado.Status)
            {
                return Ok(autorDeletado);
            }
            return BadRequest(autorDeletado);
        }
    }
}
