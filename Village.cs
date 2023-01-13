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
        private string? _gamePlayerChoice;

        public Village(string c_name)
        {
            _name = c_name;
            _myRessources = new Ressources();
            chefHome = new House();
            listHouse = new House[1] { chefHome };
            _myMine = new Mine();
            _myForest = new Forest();

            while (_gamePlayerChoice != "0" && _gamePlayerChoice != "")
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"{getName()} || Pierre {getStone()} | Bois {getWood()} | Villageois {villageois}");
                Console.WriteLine($"Ressources niveau {_myRessources.getLevel()} | Forêt niveau: {_myForest.getLevel()} | Mine niveau: {_myMine.getLevel()}");
                Console.WriteLine("");
                Console.WriteLine("Vos choix disponibles:");
                Console.WriteLine("");
                Console.WriteLine("1(nombre de villageois): Miner de la pierre | 2(nombre de villageois): Couper du bois | 3(nombre de maisons): Construire des maisons");
                Console.WriteLine("4: Améliorer les ressources | 5: Améliorer la Mine | 6: Améliorer la Forêt");
                Console.WriteLine("0: Arrêter le jeu | 9: Triche");
                Console.WriteLine("");
                Console.WriteLine("Que voulez-vous faire?");
                _gamePlayerChoice = Console.ReadLine();
                Console.WriteLine("");


                string playerParam = "";

                // Permet de vérifier si le paramètre respecte le format (collé au choix avec des chiffres à l'intérieur)
                if ((_gamePlayerChoice[0] == '1' || _gamePlayerChoice[0] == '2' || _gamePlayerChoice[0] == '3') && _gamePlayerChoice.Length > 3)
                {
                    if (_gamePlayerChoice[1] != '(' || _gamePlayerChoice[_gamePlayerChoice.Length - 1] != ')')
                    {
                        Console.WriteLine("Merci de signifier votre choix suivi du paramètre entre ()");
                    }
                    else
                    {
                        for (int i = 2; i < _gamePlayerChoice.Length - 1; i++)
                        {
                            if (_gamePlayerChoice[i] < '0' || _gamePlayerChoice[i] > '9')
                            {
                                Console.WriteLine("Le paramètre ne doit contenir que des nombres");
                            }
                            else
                            {
                                playerParam += _gamePlayerChoice[i];
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Merci de signifier votre choix suivi du paramètre entre ()");

                }

                if (_gamePlayerChoice[0] == '1')
                {
                    if (playerParam != "")
                    {
                        int nombreVillageois = Convert.ToInt32(playerParam);
                        mineStone(nombreVillageois);
                    }
                }

                else if (_gamePlayerChoice[0] == '2')
                {


                    if (playerParam != "")
                    {
                        int nombreVillageois = Convert.ToInt32(playerParam);
                        cutWood(nombreVillageois);
                    }
                }
                else if (_gamePlayerChoice[0] == '3')
                {
                    if (playerParam != "")
                    {
                        int nombreMaisons = Convert.ToInt32(playerParam);
                        buildHouse(nombreMaisons);
                    }
                }
                else if (_gamePlayerChoice[0] == '4')
                {
                    upgradeRessources();
                }
                else if (_gamePlayerChoice[0] == '5')
                {
                    upgradeMine();
                }
                else if (_gamePlayerChoice[0] == '6')
                {
                    upgradeForest();
                }
                else if (_gamePlayerChoice[0] == '9')
                {
                    triche();
                }
                else if (_gamePlayerChoice[0] == '0')
                {
                    Console.WriteLine("Merci d'avoir joué à Village Creator!");
                }
                else
                {
                    Console.WriteLine("Vous avez mal renseigné les informations");
                }

            }
        }

        public string getName()
        {
            return _name;
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

            _myRessources.usedWood(House.wood_needed);
            _myRessources.usedStone(House.stone_needed);
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
                    Console.WriteLine("Minage de pierre effectué effectué!");
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

        public void upgradeRessources()
        {
            _myRessources.upgrade();
        }

        public void upgradeMine()
        {
            if (getStone() >= 10 * Mine.gain_stone)
            {
                _myRessources.usedStone(10 * Mine.gain_stone);
                _myMine.upgrade();
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez de Pierre pour améliorer votre Mine.");
            }

        }

        public void upgradeForest()
        {
            if (getWood() >= 10 * Forest.gain_wood)
            {
                _myRessources.usedWood(10 * Forest.gain_wood);
                _myForest.upgrade();
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez de Bois pour améliorer votre Forêt.");
            }
        }




        //// METHODES TESTS!!! ------ DELETE SOON

        public void triche()
        {

            for (int i = 0; i < 500; i++)
            {
                _myRessources.lookAround();

            }
        }



    }
}