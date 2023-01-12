namespace myForest
{

    public class Forest
    {
        public static int gain_wood = 10;
        public static int stone_cost = 2;
        public static int wood_cost = 1;

        public int cutWood(int nombreVillageois)
        {
            return nombreVillageois * gain_wood;
        }
    }


}