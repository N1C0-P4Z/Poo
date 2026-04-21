using ejercicio3;

Console.WriteLine("=== EJERCICIO 3: JUGADOR CANSADO ===\n");

// Ejemplo 1: Jugador Amateur que se cansa al intentar correr 30 minutos
Console.WriteLine("--- Ejemplo 1: Amateur intenta correr 30 minutos ---");
IJugador jugador1 = new JugadorAmateur();
Console.WriteLine($"¿Está cansado? {jugador1.Cansado()}");
bool resultado1 = jugador1.Correr(30);
Console.WriteLine($"¿Pudo correr 30 minutos? {resultado1}");
Console.WriteLine($"¿Está cansado? {jugador1.Cansado()}\n");

// Ejemplo 2: Jugador Amateur que corre 10 minutos y puede seguir
Console.WriteLine("--- Ejemplo 2: Amateur corre 10 minutos y puede seguir ---");
IJugador jugador2 = new JugadorAmateur();
Console.WriteLine($"¿Está cansado? {jugador2.Cansado()}");
bool resultado2 = jugador2.Correr(10);
Console.WriteLine($"¿Pudo correr 10 minutos? {resultado2}");
Console.WriteLine($"¿Está cansado? {jugador2.Cansado()}");
bool resultado3 = jugador2.Correr(5);
Console.WriteLine($"¿Puede seguir corriendo 5 minutos más? {resultado3}");
Console.WriteLine($"¿Está cansado? {jugador2.Cansado()}");
bool resultado4 = jugador2.Correr(5);
Console.WriteLine($"¿Puede seguir corriendo 5 minutos más? {resultado4}");
Console.WriteLine($"¿Está cansado? {jugador2.Cansado()}\n");

// Descansar
Console.WriteLine("\n--- Ejemplo 3: Amateur descansa ---");
jugador2.Descansar(10);
Console.WriteLine($"Descansó 10 minutos");
Console.WriteLine($"¿Está cansado? {jugador2.Cansado()}");
bool resultado5 = jugador2.Correr(5);
Console.WriteLine($"¿Puede correr 5 minutos después de descansar? {resultado5}");


// Ejemplo 4: Jugador profesional
Console.WriteLine("--- Ejemplo 4: Profesional intenta correr 50 minutos ---");
IJugador jugador3 = new JugadorProfesional();
Console.WriteLine($"¿Está cansado? {jugador3.Cansado()}");
bool resultado6 = jugador3.Correr(50);
Console.WriteLine($"¿Pudo correr 50 minutos? {resultado6}");
Console.WriteLine($"¿Está cansado? {jugador3.Cansado()}\n");
Console.WriteLine($"¿Está cansado? {jugador3.Cansado()}\n");

//ejemplo 5: Profesional corre 30 minutos y puede seguir
Console.WriteLine("--- Ejemplo 5: Profesional corre 30 minutos y puede seguir ---");
IJugador jugador4 = new JugadorProfesional();
Console.WriteLine($"¿Está cansado? {jugador4.Cansado()}");
bool resultado7 = jugador4.Correr(30);
Console.WriteLine($"¿Pudo correr 30 minutos? {resultado7}");
Console.WriteLine($"¿Está cansado? {jugador4.Cansado()}");
bool resultado8 = jugador4.Correr(10);
Console.WriteLine($"¿Puede seguir corriendo 10 minutos más? {resultado8}");
Console.WriteLine($"¿Está cansado? {jugador4.Cansado()}\n");

// Descansar
Console.WriteLine("\n--- Ejemplo 3: Amateur descansa ---");
jugador4.Descansar(10);
Console.WriteLine($"Descansó 10 minutos");
Console.WriteLine($"¿Está cansado? {jugador4.Cansado()}");
bool resultado9 = jugador4.Correr(5);
Console.WriteLine($"¿Puede correr 5 minutos después de descansar? {resultado9}");