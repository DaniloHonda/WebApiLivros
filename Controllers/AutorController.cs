using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
