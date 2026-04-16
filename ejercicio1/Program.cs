namespace ejercicioSemaforo;

public class Semaforo {

    private string colorAct;
    private int tiempoencolor;
    private int tiempoenintermitente;
    private bool esintermitente;

    public Semaforo(string colorinicial)
    {
        colorAct = colorinicial;
        tiempoencolor = 0;
        tiempoenintermitente = 0;
        esintermitente = false;
    }

    public string mostrarcolor()
    {
        if (esintermitente)
        {
            int ciclo = tiempoenintermitente % 2;
            return ciclo == 0 ? "Amarillo" : "Apagado";
        }
        return colorAct;
    }

    private int obtenerDuracionColor(string color)
    {
        return color switch
        {
            "Rojo" => 30,
            "Verde" => 20,
            "Amarillo" => 2,
            "Rojo+Amarillo" => 2,
            _ => 0
        };
    }

    private string obtenerSiguienteColor(string color)
    {
        return color switch
        {
            "Rojo" => "Rojo+Amarillo",
            "Rojo+Amarillo" => "Verde",
            "Verde" => "Amarillo",
            "Amarillo" => "Rojo",
            _ => "Rojo"
        };
    }

    public void pasodelTiempo (int segundos)
    {
        if(esintermitente)
        {
            tiempoenintermitente += segundos;
        }
        else
        {
            tiempoencolor += segundos;
            int duracionActual = obtenerDuracionColor(colorAct);
            
            while(tiempoencolor >= duracionActual)
            {
                tiempoencolor -= duracionActual;
                colorAct = obtenerSiguienteColor(colorAct);
                duracionActual = obtenerDuracionColor(colorAct);
            }
        }
    }

    public void activarIntermitente()
    {
        esintermitente = true;
        tiempoenintermitente = 0;
    }

    public void desactivarIntermitente()
    {
        esintermitente = false;
        tiempoencolor = 0;
    }
    
}

public class Programa
{
    static void Main(string[] args)
    {
        Semaforo semaforo = new Semaforo("Verde");
            
            Console.WriteLine($"Color inicial: {semaforo.mostrarcolor()}");

            Console.WriteLine("\nSecuencia Normal:");
            semaforo.pasodelTiempo(5);
            Console.WriteLine($"Después (5s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(10);
            Console.WriteLine($"Después (15s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(5);
            Console.WriteLine($"Después (20s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(2);
            Console.WriteLine($"Después (22s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(5);
            Console.WriteLine($"Después (27s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(30);
            Console.WriteLine($"Después (57s): {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(5);
            Console.WriteLine($"Después (62s): {semaforo.mostrarcolor()}");

            Console.WriteLine("\n Activando Modo Intermitente:");
            semaforo.activarIntermitente();
            
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(1);
            Console.WriteLine($"Pasan 1 segundos → Color actual: {semaforo.mostrarcolor()}");

            Console.WriteLine("\nVolviendo a Secuencia Normal:");
            semaforo.desactivarIntermitente();
            Console.WriteLine($"Color actual: {semaforo.mostrarcolor()}");
            
            semaforo.pasodelTiempo(10);
            Console.WriteLine($"Pasan 10 segundos → Color actual: {semaforo.mostrarcolor()}");
            semaforo.pasodelTiempo(10);
            Console.WriteLine($"Pasan otros 10 segundos → Color actual: {semaforo.mostrarcolor()}");
    }
}