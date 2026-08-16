namespace Biblioteca.Domain.Entidades;

public class Livro
{
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Editora { get; private set; }

    public string Autor { get; private set; }

    public bool Disponivel { get; private set; }

    public Livro(string nome, string editora, string autor)
    {
        Nome = nome;
        Editora = editora;
        Autor = autor;
        Disponivel = true;
    }

   public void MarcarComoEmprestado()
{
    if (!Disponivel)
        throw new InvalidOperationException("O livro já está emprestado.");

    Disponivel = false;
}
    public void MarcarComoDisponivel()
    {
        Disponivel = true;
    }
}