namespace ejercicio6;

public enum TipoBaraja
    {
        Espaniola,
        Francesa
    }

    public class Mazo
    {
        private List<Carta> cartas;
        private Random random;

        public Mazo(TipoBaraja tipo)
        {
            cartas = new List<Carta>();
            random = new Random();

            if (tipo == TipoBaraja.Espaniola)
            {
                Palo[] palos = { Palo.Oros, Palo.Copas, Palo.Espadas, Palo.Bastos };
                foreach (Palo palo in palos)
                {
                    for (int numero = 1; numero <= 12; numero++)
                    {
                        cartas.Add(new CartaEspaniola(palo, numero));
                    }
                }
            }
            else
            {
                Palo[] palos = { Palo.Corazones, Palo.Diamantes, Palo.Treboles, Palo.Picas };
                foreach (Palo palo in palos)
                {
                    for (int numero = 1; numero <= 13; numero++)
                    {
                        cartas.Add(new CartaFrancesa(palo, numero));
                    }
                }
            }
        }

        public void Barajar()
        {
            for (int i = cartas.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Carta temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public Carta RobarCarta()
        {
            if (cartas.Count == 0)
            {
                throw new InvalidOperationException("El mazo está vacío.");
            }

            Carta carta = cartas[0];
            cartas.RemoveAt(0);
            return carta;
        }

        public int CuantasCartasQuedan()
        {
            return cartas.Count;
        }
    }
