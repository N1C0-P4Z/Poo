using ejercicio4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== PRUEBA DE VEHICULOS ===\n");

        // Prueba del enunciado
        Auto fiat = new Auto(45);
        Bicicleta bici = new Bicicleta();
        Camion camion = new Camion();

        Console.WriteLine("--- Bicicleta ---");
        bici.Mover(20);
        Console.WriteLine($"Posicion despues de 20s: {bici.Posicion()} metros");
        bici.Mover(10);
        Console.WriteLine($"Posicion despues de 10s mas: {bici.Posicion()} metros");

        Console.WriteLine("\n--- Auto (velocidad personalizada 45 m/s) ---");
        fiat.Mover(10);
        Console.WriteLine($"Posicion despues de 10s: {fiat.Posicion()} metros");

        Console.WriteLine("\n--- Camion ---");
        camion.Mover(10);
        Console.WriteLine($"Posicion despues de 10s: {camion.Posicion()} metros");

        Console.WriteLine("\n=== PRUEBA DE CARRERA ===\n");

        Auto autoCarrera = new Auto();
        Bicicleta biciCarrera = new Bicicleta();

        Carrera carrera = new Carrera(autoCarrera, biciCarrera);
        carrera.Competir(20);
    }
}
