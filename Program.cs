using myRessources;
using myHouse;
using myMine;
using myForest;

main();

void main()
{

    Village myVillage = new Village("Victor le createur");
    myVillage.cutWood(50); // affichera Il n'y a pas assez de villageois
    Console.WriteLine(myVillage.getStone()); // afficher 10
    Console.WriteLine(myVillage.getWood()); // afficher 10
    myVillage.cutWood(6); // affichera Il n'y a pas assez de ressource
    Console.WriteLine(myVillage.getStone()); // afficher 10
    Console.WriteLine(myVillage.getWood()); // afficher 10
    myVillage.cutWood(5); myVillage.cutWood(5); // affichera Il n'y a pas assez de ressource
    Console.WriteLine(myVillage.getStone()); // afficher 0
    Console.WriteLine(myVillage.getWood()); // afficher 55
    myVillage.cutWood(5); // affichera Il n'y a pas assez de ressource

}

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
                _myRessources.addStone(nombreVillageois * Mine.gain_stone);
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
                _myRessources.addWood(nombreVillageois * Forest.gain_wood);
            }
        }
        else
        {
            Console.WriteLine("Il n'y a pas assez de villageois!");
        }
    }
}