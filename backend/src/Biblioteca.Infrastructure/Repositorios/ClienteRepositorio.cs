using Biblioteca.Domain.Entidades;
using Biblioteca.Infrastructure.Banco;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositorios;

public class ClienteRepositorio
{
    private readonly BibliotecaDbContext _context;

    public ClienteRepositorio(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ListarTodos()
    {
        return await _context.Clientes
            .ToListAsync();
    }

    public async Task<Cliente?> BuscarPorId(int id)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Adicionar(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }
}