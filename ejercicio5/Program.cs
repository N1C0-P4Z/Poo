using ejercicio5;

Console.WriteLine("=== EJERCICIO 5: CAJERO AUTOMÁTICO ===\n");

// ============================================================
// PRUEBA 1: CajaDeAhorro
// ============================================================
Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║         PRUEBA: CAJA DE AHORRO          ║");
Console.WriteLine("╚══════════════════════════════════════════╝\n");

Console.WriteLine("1. Creando CajaDeAhorro...");
CajaDeAhorro ahorro = new CajaDeAhorro();

Console.WriteLine("2. Depositando 1000...");
ahorro.depositar(1000);
ahorro.mostrarSaldo();

Console.WriteLine("3. Extrayendo 400...");
ahorro.extraer(400);
ahorro.mostrarSaldo();

Console.WriteLine("4. Extrayendo 800 (debería rechazarse, saldo es 600)...");
ahorro.extraer(800);
ahorro.mostrarSaldo();

Console.WriteLine("\n─────────────────────────────────────────────\n");

// ============================================================
// PRUEBA 2: CuentaCorriente
// ============================================================
Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║       PRUEBA: CUENTA CORRIENTE          ║");
Console.WriteLine("╚══════════════════════════════════════════╝\n");

Console.WriteLine("1. Creando CuentaCorriente con descubierto de 500...");
CuentaCorriente corriente = new CuentaCorriente(500);

Console.WriteLine("2. Depositando 200...");
corriente.depositar(200);
corriente.mostrarSaldo();

Console.WriteLine("3. Extrayendo 600 (saldo: 200 - 600 = -400, dentro del descubierto de 500)...");
corriente.extraer(600);
corriente.mostrarSaldo();

Console.WriteLine("4. Extrayendo 200 (saldo: -400 - 200 = -600, supera el descubierto de 500)...");
corriente.extraer(200);
corriente.mostrarSaldo();

Console.WriteLine("\n─────────────────────────────────────────────\n");

// ============================================================
// PRUEBA 3: Banco con Transferencias
// ============================================================
Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║     PRUEBA: BANCO Y TRANSFERENCIAS      ║");
Console.WriteLine("╚══════════════════════════════════════════╝\n");

Console.WriteLine("1. Creando Banco...");
Banco banco = new Banco();

Console.WriteLine("2. Creando CajaDeAhorro y CuentaCorriente (descubierto 500)...");
CajaDeAhorro ahorro2 = new CajaDeAhorro();
CuentaCorriente corriente2 = new CuentaCorriente(500);

Console.WriteLine("3. Registrando ambas cuentas en el banco...");
banco.agregarCuenta(ahorro2);
banco.agregarCuenta(corriente2);

Console.WriteLine("4. Depositando 1000 en la CajaDeAhorro...");
ahorro2.depositar(1000);
ahorro2.mostrarSaldo();
corriente2.mostrarSaldo();

Console.WriteLine("5. Transfiriendo 300 desde CajaDeAhorro a CuentaCorriente...");
banco.transferir(ahorro2, corriente2, 300);
ahorro2.mostrarSaldo();
corriente2.mostrarSaldo();

Console.WriteLine("6. Transfiriendo 900 desde CajaDeAhorro a CuentaCorriente (saldo insuficiente, debe rechazarse)...");
banco.transferir(ahorro2, corriente2, 900);

Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
