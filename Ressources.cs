namespace myRessources
{

    public class Ressources
    {
        private int _woods;
        private int _stones;

        public Ressources()
        {
            _woods = 10;
            _stones = 10;
        }

        public int getWood()
        {
            return _woods;
        }

        public int getStone()
        {
            return _stones;
        }

        public void usedWood(int nbr)
        {
            if (nbr >= _woods)
            {
                _woods -= nbr;
            }
            else
            {
                Console.WriteLine("Pas assez de bois pour cette opération!");
            }
        }

        public void usedStone(int nbr)
        {
            if (nbr >= _stones)
            {
                _stones -= nbr;
            }
            else
            {
                Console.WriteLine("Pas assez de pierre pour cette opération!");
            }
        }


    }




}