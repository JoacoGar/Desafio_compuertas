using Compuertas;


// Primer linea de la tabla de la verdad
Entrada A = new Entrada(false);
Entrada B = new Entrada(false);
Entrada C = new Entrada(false);

CompuertaNot A_negado = new CompuertaNot("A negado");
A_negado.AddEntrada(A);
A_negado.CalcularSalida();

CompuertaAnd A_negado_AND_C = new CompuertaAnd("A negado AND C");
A_negado_AND_C.AddEntrada(A_negado);

