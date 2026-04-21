namespace ejercicio3;

public class JugadorAmateur : IJugador
{
    private const int LIMITE_MINUTOS = 20;
    
    public int Cansancio { get; set; } = 0;

    public bool Correr(int minutos)
    {
        if (Cansado())
        {
            return false;
        }
        if (Cansancio + minutos <= LIMITE_MINUTOS)
        {
            Cansancio += minutos;
            return true;
        }
        Cansancio = LIMITE_MINUTOS;
        return false;
    }

    public bool Cansado()
    {
        return Cansancio >= LIMITE_MINUTOS;
    }

    public void Descansar(int minutos)
    {
        Cansancio = Math.Max(0, Cansancio - minutos);
    }
}
