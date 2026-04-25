namespace ejercicio4;

public class Bicicleta : IVehiculo
{
    private const int VELOCIDAD_MAXIMA = 10;
    private int _posicion = 0;

    public void Mover(int tiempo)
    {
        _posicion += VELOCIDAD_MAXIMA * tiempo;
    }

    public int Posicion()
    {
        return _posicion;
    }

    public void ReiniciarPosicion()
    {
        _posicion = 0;
    }
}
