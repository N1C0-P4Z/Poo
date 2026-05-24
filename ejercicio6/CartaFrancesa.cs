namespace ejercicio6;

public class CartaFrancesa : Carta
{
    private static readonly Palo[] PalosFranceses = { Palo.Corazones, Palo.Diamantes, Palo.Treboles, Palo.Picas };

    public override string NombreFigura
    {
        get
        {
            return Numero switch
            {
                1 => "As",
                >= 2 and <= 10 => Numero.ToString(),
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                _ => throw new InvalidOperationException("Número fuera de rango")
            };
        }
    }

    public CartaFrancesa(Palo palo, int numero) : base(palo, numero)
    {
        if (!Array.Exists(PalosFranceses, p => p == palo))
            throw new ArgumentException($"El palo {palo} no es un palo francés válido.", nameof(palo));

        if (numero < 1 || numero > 13)
            throw new ArgumentOutOfRangeException(nameof(numero), "El número debe estar entre 1 y 13.");
    }
}
