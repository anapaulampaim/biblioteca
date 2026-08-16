using Biblioteca.Domain.Entidades;
using Biblioteca.Infrastructure.Banco;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Application.Interfaces;

namespace Biblioteca.Infrastructure.Repositorios;

public class LivroRepositorio : ILivroRepositorio
{
    private readonly BibliotecaDbContext _context;

    public LivroRepositorio(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> ListarTodos()
    {
        return await _context.Livros
            .ToListAsync();
    }

    public async Task<Livro?> BuscarPorId(int id)
    {
        return await _context.Livros
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task Adicionar(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Livro livro)
    {
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
    }
}