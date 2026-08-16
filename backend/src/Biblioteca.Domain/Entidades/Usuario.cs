using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.Entidades;

public class Usuario
{
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Email { get; private set; }

    public string SenhaHash { get; private set; }

    public PerfilUsuario Perfil { get; private set; }

    public bool Ativo { get; private set; }

    public DateTime DataCadastro { get; private set; }

    public Usuario(
        string nome,
        string email,
        string senhaHash,
        PerfilUsuario perfil)
    {
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Perfil = perfil;
        Ativo = true;
        DataCadastro = DateTime.UtcNow;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }
}