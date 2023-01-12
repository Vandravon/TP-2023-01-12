using myRessources;
using myHouse;

main();

void main()
{

    // Exercice 2: tests (ATTENTION: repasser AddHouse en public pour que ça refonctionne)
    // Village myVillage = new Village("Victor le createur");
    // myVillage.GetName(); // affichera Victor le createur
    // Console.WriteLine(myVillage.listHouse.Count); // affichera 1
    // myVillage.AddHouse();
    // myVillage.AddHouse();
    // Console.WriteLine(myVillage.listHouse.Count); // affichera 3
    // Console.WriteLine(myVillage.villageois); // affichera 30

}

public class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    public int villageois = 0;
    public List<House> listHouse;

    public Village(string c_name)
    {
        _name = c_name;
        _myRessources = new Ressources();
        listHouse = new List<House> { chefHome };
        villageois = 10 * listHouse.Count;

    }

    public void GetName()
    {
        Console.WriteLine($"Nom du village: {_name}");
    }

    public int GetWood()
    {
        return _myRessources.getWood();
    }

    public int GetStone()
    {
        return _myRessources.getStone();
    }

    private void AddHouse()
    {
        House houseToAdd = new House();
        listHouse.Add(houseToAdd);
        villageois = 10 * listHouse.Count;
    }


}