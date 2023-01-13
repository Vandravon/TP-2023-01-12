namespace myGameDependencies
{

    public class Goldmine
    {
        public static int gain_gold = 5;
        public static int stone_cost = 2;
        public static int wood_cost = 1;
        private int _level;

        public Goldmine()
        {
            _level = 1;
        }

        public int foodGather(int nombreVillageois)
        {
            return nombreVillageois * gain_gold;
        }

        public int getLevel()
        {
            return _level;
        }

        public void upgrade()
        {
            _level++;
            gain_gold = 10 * _level;
        }


    }
}