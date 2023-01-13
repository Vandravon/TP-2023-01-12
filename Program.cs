using myGame;

main();

void main()
{

    Village myVillage = new Village("Victor le createur");
    myVillage.getName();
    myVillage.cutWood(2);
    myVillage.mineStone(2);
    myVillage.cutWood(4);
    myVillage.mineStone(4);
    Console.WriteLine(myVillage.getWood()); // affiche 58
    Console.WriteLine(myVillage.getStone()); // affiche 46
    myVillage.buildHouse(2);
    Console.WriteLine(myVillage.listHouse.Length); // affiche 3
    Console.WriteLine(myVillage.villageois); // affiche 30
    myVillage.cutWood(15);
    myVillage.mineStone(15); // affiche Il n'y a pas assez de ressources
    Console.WriteLine(myVillage.getWood()); // affiche 187
    myVillage.mineStone(5);
    Console.WriteLine(myVillage.getStone()); // affiche 10
    // myVillage.buildHouse(4); // affiche Il n'y a pas assez de ressources


    Console.WriteLine(myVillage.getWood()); // affiche 187
    Console.WriteLine(myVillage.getStone()); // affiche 10

    // myVillage.upgradeRessources();

    myVillage.ressourcesPlus(300);

    myVillage.upgradeForest();
    myVillage.upgradeForest();
    myVillage.upgradeMine();
    myVillage.upgradeMine();

    Console.WriteLine(myVillage.getWood()); // affiche 187
    Console.WriteLine(myVillage.getStone()); // affiche 10



    // myVillage.upgradeRessources();

    // myVillage.ressourcesPlus(800);

    // Console.WriteLine(myVillage.getWood()); // affiche 187
    // Console.WriteLine(myVillage.getStone()); // affiche 10


}

