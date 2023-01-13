namespace myGameDependencies
{

    public class Mine
    {
        public static int gain_stone = 10;
        public static int stone_cost = 2;
        public static int wood_cost = 1;
        private int _level;

        public Mine()
        {
            // Console.WriteLine("Mine created!");
            _level = 1;
        }

        public int mineStone(int nombreVillageois)
        {
            return nombreVillageois * gain_stone + 10 * _level;
        }

        public int getLevel()
        {
            return _level;
        }

        public void upgrade()
        {
            _level++;
            gain_stone = 10 * _level;
        }


    }
}