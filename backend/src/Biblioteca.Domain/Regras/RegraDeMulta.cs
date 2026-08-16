namespace Biblioteca.Domain.Regras;

public static class RegraDeMulta
{
    private const decimal ValorPorDia = 5.00m;

    public static decimal Calcular(DateTime dataPrevista, DateTime dataDevolucao)
    {
        if (dataDevolucao <= dataPrevista)
            return 0;

        var diasDeAtraso = (dataDevolucao.Date - dataPrevista.Date).Days;

        return diasDeAtraso * ValorPorDia;
    }
}