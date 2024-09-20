namespace Compuertas;

public class Entrada : IEntradas
{
    private bool Valor { get; set; }

    public Entrada(bool valor)
    {
        this.Valor = valor;
    }

    public bool DevolverEntrada()
    {
        return Valor;
    }
}