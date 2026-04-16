namespace ejercicioCronometro;

public class Cronometro
{
    private int minutos;
    private int segundos;

    public Cronometro()
    {
        minutos = 0;
        segundos = 0;
    }

    public void reiniciar()
    {
        minutos = 0;
        segundos = 0;
    }

    public void incrementarTiempo()
    {
        segundos++;
        if (segundos > 59)
        {
            minutos++;
            segundos = 0;
        }
    }

    public string mostrarTiempo()
    {
        return $"{minutos} minutos, {segundos} segundos";
    }
}

public class Programa
{
    static void Main(string[] args)
    {
        Cronometro cronometro = new Cronometro();

        Console.WriteLine("Iniciando cronómetro...");
        Console.WriteLine($"Tiempo inicial: {cronometro.mostrarTiempo()}");

        for (int i = 0; i < 5000; i++)
        {
            cronometro.incrementarTiempo();
        }

        Console.WriteLine($"\nDespués de 5000 incrementos: {cronometro.mostrarTiempo()}");

        // Pruebas adicionales
        Console.WriteLine("\n--- Pruebas Adicionales ---");
        cronometro.reiniciar();
        Console.WriteLine($"Después de reiniciar: {cronometro.mostrarTiempo()}");

        for (int i = 0; i < 125; i++)
        {
            cronometro.incrementarTiempo();
        }
        Console.WriteLine($"Después de 125 incrementos: {cronometro.mostrarTiempo()}");
    }
}
