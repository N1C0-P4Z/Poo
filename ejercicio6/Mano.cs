namespace ejercicio6;

public class Mano
{
    private List<Carta> cartas;

    public Mano()
    {
        cartas = new List<Carta>();
    }

    public void RecibirCarta(Carta carta)
    {
        cartas.Add(carta);
    }

    public void MostrarMano()
    {
        if (cartas.Count == 0)
        {
            Console.WriteLine("No hay cartas.");
            return;
        }

        foreach (Carta carta in cartas)
        {
            Console.WriteLine(carta);
        }
    }

    public int CantidadDeCartas()
    {
        return cartas.Count;
    }
}
