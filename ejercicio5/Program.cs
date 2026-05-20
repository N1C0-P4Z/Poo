using ejercicio5;

Console.WriteLine("=== EJERCICIO 5: CAJERO AUTOMÁTICO ===\n");

// Prueba CajaDeAhorro
Console.WriteLine("--- Caja de Ahorro ---");
CajaDeAhorro ahorro = new CajaDeAhorro();
ahorro.depositar(1000);
ahorro.extraer(400);
ahorro.extraer(800); // debe rechazarse
ahorro.mostrarSaldo(); // debe mostrar 600

Console.WriteLine();

// Prueba CuentaCorriente
Console.WriteLine("--- Cuenta Corriente ---");
CuentaCorriente corriente = new CuentaCorriente(500);
corriente.depositar(200);
corriente.extraer(600); // queda en -400, es válido
corriente.extraer(200); // supera el descubierto, debe rechazarse
corriente.mostrarSaldo(); // debe mostrar -400

Console.WriteLine();

// Prueba Banco con transferencias
Console.WriteLine("--- Banco ---");
Banco banco = new Banco();
CajaDeAhorro ahorro2 = new CajaDeAhorro();
CuentaCorriente corriente2 = new CuentaCorriente(500);

banco.agregarCuenta(ahorro2);
banco.agregarCuenta(corriente2);

ahorro2.depositar(1000);

banco.transferir(ahorro2, corriente2, 300); // debe funcionar
ahorro2.mostrarSaldo(); // 700
corriente2.mostrarSaldo(); // 300

banco.transferir(ahorro2, corriente2, 900); // debe rechazarse, saldo insuficiente
