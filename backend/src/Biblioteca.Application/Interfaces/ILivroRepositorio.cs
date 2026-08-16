using Biblioteca.Domain.Entidades;

namespace Biblioteca.Application.Interfaces;

public interface ILivroRepositorio
{
    Task<List<Livro>> ListarTodos();

    Task<Livro?> BuscarPorId(int id);

    Task Adicionar(Livro livro);
}