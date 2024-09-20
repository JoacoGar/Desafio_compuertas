namespace Compuertas;

public class CompuertaAnd : ICompuertas
{
    public string Name { get; set; }
    public List<IEntradas> EntradasDeCompuerta { get; set; }
    
    public CompuertaAnd (string name)
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
        return (EntradasDeCompuerta[0].EsBooleano() && 
    }
}
