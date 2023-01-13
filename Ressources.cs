namespace myGameDependencies
{

    public class Ressources
    {
        private int _woods;
        private int _stones;
        private int _golds;
        private int _level;
        private int _woods_max;
        private int _stones_max;
        private int _gold_max;

        public Ressources()
        {
            _woods = 10;
            _stones = 10;
            _golds = 0;
            _level = 1;
            _woods_max = 250;
            _stones_max = 250;
            _gold_max = 50;
        }

        public int getWood()
        {
            return _woods;
        }

        public int getStone()
        {
            return _stones;
        }

        public int getGold()
        {
            return _golds;
        }

        public void usedWood(int nbr)
        {
            if (nbr <= _woods)
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
            if (nbr <= _stones)
            {
                _stones -= nbr;
            }
            else
            {
                Console.WriteLine("Pas assez de pierre pour cette opération!");
            }
        }

        public void usedGold(int nbr)
        {
            if (nbr <= _golds)
            {
                _golds -= nbr;
            }
            else
            {
                Console.WriteLine("Pas assez d'or pour cette opération!");
            }
        }

        public void addStone(int nbr)
        {
            _stones += nbr;
            if (_stones > _stones_max)
            {
                _stones = _stones_max;
            }
        }

        public void addWood(int nbr)
        {
            _woods += nbr;
            if (_woods > _woods_max)
            {
                _woods = _woods_max;
            }
        }

        public void addGold(int nbr)
        {
            _golds += nbr;
            if (_golds > _gold_max)
            {
                _golds = _gold_max;
            }
        }

        public int getLevel()
        {
            return _level;
        }

        public void upgrade()
        {
            if (_stones >= (int)Math.Round(0.8 * _stones_max) && _woods >= (int)Math.Round(0.8 * _woods_max) && _golds >= (int)Math.Round(0.8 * _gold_max))
            {
                _stones -= (int)Math.Round(0.8 * _stones_max);
                _woods -= (int)Math.Round(0.8 * _woods_max);
                _golds -= (int)Math.Round(0.8 * _gold_max);
                _woods_max = _woods_max * 2;
                _stones_max = _stones_max * 2;
                _gold_max = _gold_max * 2;
                _level++;
                Console.WriteLine("Bravo, vous voilà au niveau " + _level + " !");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez de ressources pour augmenter de niveau de Ressources!");
            }
        }

        public void lookAround()
        {
            if (_level >= 1)
            {
                _woods++;
                _stones++;
                if (_stones > _stones_max)
                {
                    _stones = _stones_max;
                }
                if (_woods > _woods_max)
                {
                    _woods = _woods_max;
                }
            }
            else
            {
                Console.WriteLine("Impossible, votre niveau de ressource est trop bas!");
            }
        }


    }




}