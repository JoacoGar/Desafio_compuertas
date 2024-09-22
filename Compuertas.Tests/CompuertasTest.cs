using NUnit.Framework;
using Compuertas;

namespace Compuertas.Tests
{
    public class CompuertasTest
    {
        [Test]
        [TestCase(false, false, false, true, false, false)]  // A=0, B=0, C=0
        [TestCase(false, false, true, true, true, true)]     // A=0, B=0, C=1
        [TestCase(false, true, false, true, false, true)]    // A=0, B=1, C=0
        [TestCase(false, true, true, true, true, true)]      // A=0, B=1, C=1
        [TestCase(true, false, false, false, false, false)]  // A=1, B=0, C=0
        [TestCase(true, false, true, false, false, false)]   // A=1, B=0, C=1
        [TestCase(true, true, false, false, false, true)]    // A=1, B=1, C=0
        [TestCase(true, true, true, false, false, true)]     // A=1, B=1, C=1
        public void TestTablaDeVerdad(bool a, bool b, bool c, bool NotA, bool And, bool Or)
        {
            var entradaA = new Entrada(a);
            var notGateA = new CompuertaNot();
            notGateA.AddEntrada(entradaA);
            var resultadoNotA = notGateA.CalcularSalida();
            Assert.AreEqual(NotA, resultadoNotA, $"El resultado de A negado debería ser {NotA}");

            var entradaC = new Entrada(c);
            var andGate = new CompuertaAnd();
            andGate.AddEntrada(notGateA); 
            andGate.AddEntrada(entradaC); 
            var resultadoAnd = andGate.CalcularSalida();
            Assert.AreEqual(And, resultadoAnd, $"El resultado de A negado AND C debería ser {And}");

            
            var entradaB = new Entrada(b);
            var orGate = new CompuertaOr();
            orGate.AddEntrada(andGate); 
            orGate.AddEntrada(entradaB); 
            var resultadoOr = orGate.CalcularSalida();
            Assert.AreEqual(Or, resultadoOr, $"El resultado de A negado AND C || B debería ser {Or}");
        }
    }
}
