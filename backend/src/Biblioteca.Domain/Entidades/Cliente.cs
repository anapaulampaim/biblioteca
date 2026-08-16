namespace Biblioteca.Domain.Entidades;

public class Cliente
{
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Cpf { get; private set; }

    public string Telefone { get; private set; }

    public Cliente(string nome, string cpf, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
    }
}