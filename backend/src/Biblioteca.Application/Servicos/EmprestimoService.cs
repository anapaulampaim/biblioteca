using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entidades;

namespace Biblioteca.Application.Servicos;

public class EmprestimoService
{
    private const int LimiteEmprestimosPorCliente = 2;

    private readonly IEmprestimoRepositorio _emprestimoRepositorio;

    public EmprestimoService(IEmprestimoRepositorio emprestimoRepositorio)
    {
        _emprestimoRepositorio = emprestimoRepositorio;
    }

    public async Task RealizarEmprestimo(Livro livro, Cliente cliente)
    {
        var quantidadeEmprestimos =
            _emprestimoRepositorio.ContarEmprestimosAtivosPorCliente(cliente.Id);

        if (quantidadeEmprestimos >= LimiteEmprestimosPorCliente)
            throw new InvalidOperationException(
                "O cliente já possui o limite máximo de 2 livros emprestados.");

        var emprestimo = new Emprestimo(livro, cliente);

       await _emprestimoRepositorio.Adicionar(emprestimo);
}
    public async Task RegistrarDevolucao(int emprestimoId)
{
        var emprestimo = await _emprestimoRepositorio.BuscarPorId(emprestimoId);

        if (emprestimo == null)
            throw new InvalidOperationException(
                 "Empréstimo não encontrado.");

        emprestimo.RegistrarDevolucao();

        await _emprestimoRepositorio.Atualizar(emprestimo);
}




}
