using Microsoft.AspNetCore.Mvc;
using WebApiLivros.Dto.Autor;
using WebApiLivros.Models;
using WebApiLivros.Services.Autor;
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

    }
}
