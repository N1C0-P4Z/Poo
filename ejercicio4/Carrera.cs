namespace ejercicio4;

public class Carrera
{
    private IVehiculo _vehiculo1;
    private IVehiculo _vehiculo2;

    public Carrera(IVehiculo vehiculo1, IVehiculo vehiculo2)
    {
        _vehiculo1 = vehiculo1;
        _vehiculo2 = vehiculo2;
    }

    public void Competir(int segundos)
    {
        _vehiculo1.ReiniciarPosicion();
        _vehiculo2.ReiniciarPosicion();

        _vehiculo1.Mover(segundos);
        _vehiculo2.Mover(segundos);

        Console.WriteLine($"Posición final vehículo 1: {_vehiculo1.Posicion()} metros");
        Console.WriteLine($"Posición final vehículo 2: {_vehiculo2.Posicion()} metros");

        if (_vehiculo1.Posicion() > _vehiculo2.Posicion())
        {
            Console.WriteLine("El vehículo 1 llegó más lejos.");
        }
        else if (_vehiculo2.Posicion() > _vehiculo1.Posicion())
        {
            Console.WriteLine("El vehículo 2 llegó más lejos.");
        }
        else
        {
            Console.WriteLine("Ambos vehículos llegaron a la misma posición.");
        }
    }
}
