namespace ejercicio5;

public class CuentaBancaria
{
    protected decimal saldo;

    public CuentaBancaria()
    {
        saldo = 0;
    }

    public void depositar(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede depositar un monto negativo o cero.");
            return;
        }
        saldo += monto;
    }

    public virtual bool extraer(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede extraer un monto negativo o cero.");
            return false;
        }
        if (monto > saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
            return false;
        }
        saldo -= monto;
        return true;
    }

    public void mostrarSaldo()
    {
        Console.WriteLine($"Saldo actual: {saldo}");
    }
}
