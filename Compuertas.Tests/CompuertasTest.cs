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
            //  A negado
            var entradaA = new Entrada(a);
            var notGateA = new CompuertaNot();
            notGateA.AddEntrada(entradaA);
            var resultadoNotA = notGateA.CalcularSalida();
            Assert.AreEqual(NotA, resultadoNotA, $"El resultado de !A debería ser {NotA}");

            // A negado y C
            var entradaC = new Entrada(c);
            var andGate = new CompuertaAnd();
            andGate.AddEntrada(notGateA); 
            andGate.AddEntrada(entradaC); 
            var resultadoAnd = andGate.CalcularSalida();
            Assert.AreEqual(And, resultadoAnd, $"El resultado de !A && C debería ser {And}");

            // Compuerta OR ((!A && C) || B)
            var entradaB = new Entrada(b);
            var orGate = new CompuertaOr();
            orGate.AddEntrada(andGate); // !A && C
            orGate.AddEntrada(entradaB); // B
            var resultadoOr = orGate.CalcularSalida();
            Assert.AreEqual(Or, resultadoOr, $"El resultado de (!A && C) || B debería ser {Or}");
        }
    }
}
