using Biblioteca.Domain.Entidades;
using Biblioteca.Infrastructure.Banco;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Enums;

namespace Biblioteca.Infrastructure.Repositorios;

public class EmprestimoRepositorio : IEmprestimoRepositorio
{
    private readonly BibliotecaDbContext _context;

    public EmprestimoRepositorio(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Emprestimo>> ListarTodos()
    {
        return await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Cliente)
            .ToListAsync();
    }

    public async Task<Emprestimo?> BuscarPorId(int id)
    {
        return await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Cliente)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
public int ContarEmprestimosAtivosPorCliente(int clienteId)
{
    return _context.Emprestimos
        .Count(e =>
            e.Cliente.Id == clienteId &&
            e.Status == StatusEmprestimo.Ativo);
}
    public async Task Adicionar(Emprestimo emprestimo)
    {
        await _context.Emprestimos.AddAsync(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Emprestimo emprestimo)
    {
        _context.Emprestimos.Update(emprestimo);
        await _context.SaveChangesAsync();
    }
}