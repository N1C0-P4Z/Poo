namespace ejercicio4;

public class Auto : IVehiculo
{
    private int _velocidadMaxima;
    private int _posicion = 0;

    public Auto(int velocidadMaxima = 40)
    {
        _velocidadMaxima = velocidadMaxima;
    }

    public void Mover(int tiempo)
    {
        _posicion += _velocidadMaxima * tiempo;
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
