namespace myGameDependencies
{

    public class Field
    {
        public static int gain_food = 10;
        public static int stone_cost = 2;
        public static int wood_cost = 1;
        public static int food_cost = 1;
        private int _level;

        public Field()
        {
            _level = 1;
        }

        public int foodGather(int nombreVillageois)
        {
            return nombreVillageois * gain_food;
        }

        public int getLevel()
        {
            return _level;
        }

        public void upgrade()
        {
            _level++;
            gain_food = 10 * _level;
        }


    }
}