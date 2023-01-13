namespace myGameDependencies
{

    public class Forest
    {
        public static int gain_wood = 10;
        public static int stone_cost = 2;
        public static int wood_cost = 1;
        private int _level;

        public Forest()
        {
            _level = 1;
        }

        public int cutWood(int nombreVillageois)
        {
            return nombreVillageois * gain_wood;
        }

        public int getLevel()
        {
            return _level;
        }

        public void upgrade()
        {
            _level++;
            gain_wood = 10 * _level;
        }


    }
}