using myGameDependencies;

namespace myGame
{
    public class Village
    {
        private string _name;
        private Ressources _myRessources;
        public House chefHome;
        public int villageois
        {
            get
            {
                return House.villageois * listHouse.Length;
            }
        }
        public House[] listHouse;
        private Mine _myMine;
        private Forest _myForest;

        public Village(string c_name)
        {
            _name = c_name;
            _myRessources = new Ressources();
            chefHome = new House();
            listHouse = new House[1] { chefHome };
            _myMine = new Mine();
            _myForest = new Forest();
        }

        public void getName()
        {
            Console.WriteLine($"Nom du village: {_name}");
        }

        public int getWood()
        {
            return _myRessources.getWood();
        }

        public int getStone()
        {
            return _myRessources.getStone();
        }

        private void addHouse()
        {
            House[] newListHouse = new House[listHouse.Length + 1];
            House houseToAdd = new House();

            for (int i = 0; i < listHouse.Length; i++)
            {
                newListHouse[i] = listHouse[i];
            }
            newListHouse[newListHouse.Length - 1] = houseToAdd;
            listHouse = newListHouse;
        }

        public void mineStone(int nombreVillageois)
        {
            if (nombreVillageois > 0 && nombreVillageois <= this.villageois)
            {
                if (nombreVillageois * Mine.stone_cost > getStone() || nombreVillageois * Mine.wood_cost > getWood())
                {
                    Console.WriteLine("Pas assez de ressources");
                }
                else
                {
                    _myRessources.usedStone(nombreVillageois * Mine.stone_cost);
                    _myRessources.usedWood(nombreVillageois * Mine.wood_cost);
                    _myRessources.addStone(_myMine.mineStone(nombreVillageois));
                }
            }
            else
            {
                Console.WriteLine("Il n'y a pas assez de villageois!");
            }
        }

        public void cutWood(int nombreVillageois)
        {
            if (nombreVillageois > 0 && nombreVillageois <= this.villageois)
            {
                if (nombreVillageois * Forest.stone_cost > getStone() || nombreVillageois * Forest.wood_cost > getWood())
                {
                    Console.WriteLine("Pas assez de ressources");
                }
                else
                {
                    _myRessources.usedStone(nombreVillageois * Forest.stone_cost);
                    _myRessources.usedWood(nombreVillageois * Forest.wood_cost);
                    _myRessources.addWood(_myForest.cutWood(nombreVillageois));
                }
            }
            else
            {
                Console.WriteLine("Il n'y a pas assez de villageois!");
            }
        }

        public void buildHouse(int numberHouses)
        {

            // Conditions à respecter: vérifier qu'il y a assez de ressources pour construire!
            if (numberHouses <= 0)
            {
                Console.WriteLine("Merci d'indiquer un nombre positif");
            }
            else
            {
                if (numberHouses * House.wood_needed > getWood() || numberHouses * House.stone_needed > getStone())
                {
                    Console.WriteLine("Pas assez de ressources");
                }
                else
                {
                    // Permet d'ajouter des maisons en changeant listHouse
                    House[] newListHouse = new House[listHouse.Length + numberHouses];
                    House houseToAdd = new House();

                    for (int i = 0; i < listHouse.Length; i++)
                    {
                        newListHouse[i] = listHouse[i];
                    }
                    newListHouse[newListHouse.Length - 1] = houseToAdd;
                    listHouse = newListHouse;
                    _myRessources.usedStone(numberHouses * House.stone_needed);
                    _myRessources.usedWood(numberHouses * House.wood_needed);

                }
            }
        }




        //// METHODES TESTS!!! ------ DELETE SOON

        public void ressourcesPlus(int nb)
        {

            for (int i = 0; i < nb; i++)
            {
                _myRessources.lookAround();

            }
        }

        public void ressourcesLevelPlus()
        {
            _myRessources.upgrade();
        }

    }
}