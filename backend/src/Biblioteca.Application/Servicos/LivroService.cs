using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entidades;

namespace Biblioteca.Application.Servicos;

public class LivroService
{
    private readonly ILivroRepositorio _livroRepositorio;

    public LivroService(ILivroRepositorio livroRepositorio)
    {
        _livroRepositorio = livroRepositorio;
    }

    public async Task<List<Livro>> ListarTodos()
    {
        return await _livroRepositorio.ListarTodos();
    }

    public async Task<Livro?> BuscarPorId(int id)
    {
        return await _livroRepositorio.BuscarPorId(id);
    }

    public async Task Adicionar(Livro livro)
    {
        await _livroRepositorio.Adicionar(livro);
    }
}