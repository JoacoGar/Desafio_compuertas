namespace Compuertas;

public class CompuertaNot : ICompuertas
{
    private string Name { get; set; }
    private List<IEntradas> EntradasDeCompuerta { get; set; }
    
    public CompuertaNot (string name)
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
        return !EntradasDeCompuerta[0].DevolverEntrada();
    }
}

