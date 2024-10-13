using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Dto.Autor;
using ProjetoCrud.Dto.Livro;
using ProjetoCrud.Model;
using ProjetoCrud.Services.Autor;
using ProjetoCrud.Services.Livro;

namespace ProjetoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        //ActionResult pq ele pode nos retornar um 200, 404, 500 retorna um status code
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livro);
        }
    }
}
