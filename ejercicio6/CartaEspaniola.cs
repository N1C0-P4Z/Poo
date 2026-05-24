namespace ejercicio6;

public class CartaEspaniola : Carta
{
    private static readonly Palo[] PalosEspanoles = { Palo.Oros, Palo.Copas, Palo.Espadas, Palo.Bastos };

    public override string NombreFigura
    {
        get
        {
            return Numero switch
            {
                1 => "As",
                >= 2 and <= 9 => Numero.ToString(),
                10 => "Sota",
                11 => "Caballo",
                12 => "Rey",
                _ => throw new InvalidOperationException("Número fuera de rango")
            };
        }
    }

    public CartaEspaniola(Palo palo, int numero) : base(palo, numero)
    {
        if (!Array.Exists(PalosEspanoles, p => p == palo))
            throw new ArgumentException($"El palo {palo} no es un palo español válido.", nameof(palo));

        if (numero < 1 || numero > 12)
            throw new ArgumentOutOfRangeException(nameof(numero), "El número debe estar entre 1 y 12.");
    }
}
