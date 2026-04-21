namespace ejercicio3;

public class JugadorProfesional : IJugador
{
    private const int LIMITE_MAXIMO = 40;
    
    public int Cansancio { get; set; } = 0;

    public bool Correr(int minutos)
    {
        if (Cansado())
        {
            return false;
        }

        if (Cansancio + minutos <= LIMITE_MAXIMO)
        {
            Cansancio += minutos;
            return true;
        }

        Cansancio = LIMITE_MAXIMO;
        return false;
    }

    public bool Cansado()
    {
        return Cansancio >= LIMITE_MAXIMO;
    }

    public void Descansar(int minutos)
    {
        Cansancio = Math.Max(0, Cansancio - minutos);
    }
}
