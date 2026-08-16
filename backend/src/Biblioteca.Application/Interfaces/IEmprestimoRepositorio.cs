using Biblioteca.Domain.Entidades;

namespace Biblioteca.Application.Interfaces;

public interface IEmprestimoRepositorio
{
    int ContarEmprestimosAtivosPorCliente(int clienteId);

    Task<Emprestimo?> BuscarPorId(int id);

    Task Adicionar(Emprestimo emprestimo);

    Task Atualizar(Emprestimo emprestimo);
}