using Biblioteca.Application.Servicos;
using Biblioteca.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("livros")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _livroService;

    public LivrosController(LivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var livros = await _livroService.ListarTodos();

        return Ok(livros);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Livro livro)
    {
        await _livroService.Adicionar(livro);

        return Ok(livro);
    }
}