namespace Compuertas;

public interface ICompuertas
{
    public void CalcularAnd(IEntradas entradas);
    public void CalcularOr(IEntradas entradas);
    public void CalcularNot(IEntradas entradas);
}