using myRessources;
using myHouse;

main();

void main()
{


}

public class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    private int _villageois = 0;

    public Village(string c_name)
    {
        _name = c_name;
        _myRessources = new Ressources();
        _myHouse = new House();
        _villageois += 10;
    }

    public string GetName()
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


}