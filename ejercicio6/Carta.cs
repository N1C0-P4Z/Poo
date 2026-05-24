namespace ejercicio6;

/// <summary>
/// Todos los palos posibles cubriendo ambas barajas
/// </summary>
public enum Palo
{
    // Baraja española
    Oros,
    Copas,
    Espadas,
    Bastos,
    // Baraja francesa
    Corazones,
    Diamantes,
    Treboles,
    Picas
}

/// <summary>
/// Clase base abstracta que representa una carta.
/// Inmutable: no puede modificarse una vez creada.
/// </summary>
public abstract class Carta
{
    public Palo Palo { get; }
    public int Numero { get; }
    public abstract string NombreFigura { get; }

    public Carta(Palo palo, int numero)
    {
        Palo = palo;
        Numero = numero;
    }

    public override string ToString()
    {
        return $"{NombreFigura} de {Palo}";
    }
}
