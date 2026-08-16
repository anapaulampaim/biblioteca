using Biblioteca.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Banco;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Livro> Livros => Set<Livro>();

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
}