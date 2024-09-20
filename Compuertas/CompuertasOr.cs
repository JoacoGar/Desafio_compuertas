namespace Compuertas;

public class CompuertaOr : ICompuertas
{
    private string Name { get; set; }
    private List<IEntradas> EntradasDeCompuerta { get; set; }
    
    public CompuertaOr (string name)
    {
        this.Name = name;
        this.EntradasDeCompuerta = new List<IEntradas>();
    }

    public void AddEntrada(IEntradas entrada)
    {
        EntradasDeCompuerta.Add(entrada);
    }

    public bool CalcularSalida()
    {
        return (EntradasDeCompuerta[0].DevolverEntrada() || EntradasDeCompuerta[1].DevolverEntrada());
    }
}

