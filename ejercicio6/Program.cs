using ejercicio6;

Console.WriteLine("=== MAZO ESPAÑOL (48 cartas) ===\n");

Mazo mazoEspanol = new Mazo(TipoBaraja.Espaniola);
mazoEspanol.Barajar();

Mano jugador1 = new Mano();
Mano jugador2 = new Mano();

for (int i = 0; i < 3; i++)
{
    jugador1.RecibirCarta(mazoEspanol.RobarCarta());
    jugador2.RecibirCarta(mazoEspanol.RobarCarta());
}

Console.WriteLine("--- Mano del Jugador 1 ---");
jugador1.MostrarMano();

Console.WriteLine("\n--- Mano del Jugador 2 ---");
jugador2.MostrarMano();

Console.WriteLine($"\nCartas restantes en el mazo: {mazoEspanol.CuantasCartasQuedan()}");


Console.WriteLine("\n========================================\n");
Console.WriteLine("=== MAZO FRANCÉS (52 cartas) ===\n");

Mazo mazoFrances = new Mazo(TipoBaraja.Francesa);
mazoFrances.Barajar();

Mano jugador3 = new Mano();
Mano jugador4 = new Mano();

for (int i = 0; i < 3; i++)
{
    jugador3.RecibirCarta(mazoFrances.RobarCarta());
    jugador4.RecibirCarta(mazoFrances.RobarCarta());
}

Console.WriteLine("--- Mano del Jugador 3 ---");
jugador3.MostrarMano();

Console.WriteLine("\n--- Mano del Jugador 4 ---");
jugador4.MostrarMano();

Console.WriteLine($"\nCartas restantes en el mazo: {mazoFrances.CuantasCartasQuedan()}");
