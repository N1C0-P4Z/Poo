namespace ejercicio5;

public class CuentaCorriente : CuentaBancaria
{
    private decimal limiteDescubierto;

    public CuentaCorriente(decimal limiteDescubierto)
    {
        this.limiteDescubierto = limiteDescubierto;
    }

    public override bool extraer(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede extraer un monto negativo o cero.");
            return false;
        }
        if (monto > saldo + limiteDescubierto)
        {
            Console.WriteLine("Supera el límite de descubierto permitido.");
            return false;
        }
        saldo -= monto;
        return true;
    }
}
