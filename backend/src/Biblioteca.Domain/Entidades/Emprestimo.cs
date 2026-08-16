using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Regras;

namespace Biblioteca.Domain.Entidades;

public class Emprestimo
{
    public int Id { get; private set; }

   public Livro Livro { get; private set; } = null!;

public Cliente Cliente { get; private set; } = null!;
    public DateTime DataRetirada { get; private set; }

    public DateTime DataPrevistaDevolucao { get; private set; }

    public DateTime? DataDevolucao { get; private set; }

    public decimal Multa { get; private set; }

    public StatusEmprestimo Status { get; private set; }

    private Emprestimo()
{
}

    public Emprestimo(Livro livro, Cliente cliente)
    {
        Livro = livro;
        Cliente = cliente;

        DataRetirada = DateTime.UtcNow;
        DataPrevistaDevolucao = DataRetirada.AddDays(15);

        Multa = 0;
        Status = StatusEmprestimo.Ativo;

        Livro.MarcarComoEmprestado();
    }

    public void RegistrarDevolucao()
    {
        if (Status == StatusEmprestimo.Devolvido)
            return;

        DataDevolucao = DateTime.UtcNow;

        Multa = RegraDeMulta.Calcular(
            DataPrevistaDevolucao,
            DataDevolucao.Value);

        Status = StatusEmprestimo.Devolvido;

        Livro.MarcarComoDisponivel();
    }
}