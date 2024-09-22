using NUnit.Framework;
using Compuertas;

namespace Compuertas.test
{
    public class CompuertasTest
    {
        [Test]
        [TestCase(false, false, false, true, false, false)]  
        [TestCase(false, false, true, true, true, true)]     
        [TestCase(false, true, false, true, false, true)]   
        [TestCase(false, true, true, true, true, true)]      
        [TestCase(true, false, false, false, false, false)]  
        [TestCase(true, false, true, false, false, false)]   
        [TestCase(true, true, false, false, false, true)]    
        [TestCase(true, true, true, false, false, true)]     
        public void TestTablaDeVerdad(bool a, bool b, bool c, bool NotA, bool And, bool Or)
        {
            var entradaA = new Entrada(a);
            var notGateA = new CompuertaNot("NOT Gate");  // Constructor con nombre
            notGateA.AddEntrada(entradaA);
            var resultadoNotA = notGateA.CalcularSalida();
            Assert.AreEqual(NotA, resultadoNotA, $"El resultado de A negado debería ser {NotA}");

            var entradaC = new Entrada(c);
            var andGate = new CompuertaAnd("AND Gate");  // Constructor con nombre
            andGate.AddEntrada(entradaA);  // Usamos entradaA ya que es la entrada original
            andGate.AddEntrada(entradaC); 
            var resultadoAnd = andGate.CalcularSalida();
            Assert.AreEqual(And, resultadoAnd, $"El resultado de A negado AND C debería ser {And}");

            var entradaB = new Entrada(b);
            var orGate = new CompuertaOr("OR Gate");  // Constructor con nombre
            var entradaAnd = new Entrada(resultadoAnd); // Agregar la salida de AND como entrada
            orGate.AddEntrada(entradaAnd);  // Usamos la salida de la compuerta AND
            orGate.AddEntrada(entradaB); 
            var resultadoOr = orGate.CalcularSalida();
            Assert.AreEqual(Or, resultadoOr, $"El resultado de A negado AND C || B debería ser {Or}");
        }
    }
}

