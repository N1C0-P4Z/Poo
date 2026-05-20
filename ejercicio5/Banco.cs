namespace ejercicio5;

public class Banco
{
    private List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

    public void agregarCuenta(CuentaBancaria cuenta)
    {
        cuentas.Add(cuenta);
    }

    public void transferir(CuentaBancaria origen, CuentaBancaria destino, decimal monto)
    {
        if (!cuentas.Contains(origen) || !cuentas.Contains(destino))
        {
            Console.WriteLine("Una o ambas cuentas no están registradas en el banco.");
            return;
        }

        if (monto <= 0)
        {
            Console.WriteLine("El monto de la transferencia debe ser positivo.");
            return;
        }

        if (origen.extraer(monto))
        {
            destino.depositar(monto);
            Console.WriteLine($"Transferencia de {monto} realizada con éxito.");
        }
        else
        {
            Console.WriteLine("Transferencia rechazada.");
        }
    }
}
