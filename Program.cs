using myRessources;
using myHouse;

main();

void main()
{

    // Exercice 2: tests (ATTENTION: repasser AddHouse en public pour que ça refonctionne)
    Village myVillage = new Village("Victor le createur");
    myVillage.getName(); // affichera Victor le createur
    Console.WriteLine(myVillage.listHouse.Length); // affichera 1
    myVillage.addHouse();
    myVillage.addHouse();
    Console.WriteLine(myVillage.listHouse.Length); // affichera 3
    Console.WriteLine(myVillage.villageois); // affichera 30

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
            return House.villageois * listHouse.Length; ;
        }
    }
    public House[] listHouse;

    public Village(string c_name)
    {
        _name = c_name;
        _myRessources = new Ressources();
        listHouse = new House[1] { chefHome };
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

    public void addHouse()
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


}