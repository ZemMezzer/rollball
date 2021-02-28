using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilder : IChunkBuilder
{ 
    EnvObjFactory treeFactroy;
    EnvObjFactory buildingFactory;
    EnvObjFactory bigBuildingFactory;
    EnvObjFactory lampFactory;
    EnvObjFactory characterFactory;
    EnvObjFactory carFactory;

    public ChunkBuilder(EnvironmentObject tree, EnvironmentObject building, EnvironmentObject bigBuilding, EnvironmentObject lamp, EnvironmentObject character, EnvironmentObject car)
    {
        treeFactroy = new EnvObjFactory(tree);
        buildingFactory = new EnvObjFactory(building);
        bigBuildingFactory = new EnvObjFactory(bigBuilding);
        lampFactory = new EnvObjFactory(lamp);
        characterFactory = new EnvObjFactory(character);
        carFactory = new EnvObjFactory(car);
    }

    public void BuildBuilding(Vector3 position, Transform parent)
    {
        switch (Randomize.Next(0, 1))
        {
            case 0:
                var building = buildingFactory.Create();
                building.transform.SetParent(parent);
                building.transform.localPosition = position;
                building.transform.rotation = new Quaternion(0, 0, 0, 1);
                building.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 1:
                var bigBuilding = bigBuildingFactory.Create();
                bigBuilding.transform.SetParent(parent);
                bigBuilding.transform.localPosition = position;
                bigBuilding.transform.rotation = new Quaternion(0, 0, 0, 1);
                bigBuilding.transform.localScale = new Vector3(1, 1, 1);
                break;
        }
        
    }

    public void BuildLamps(Transform parent)
    {
        var lamp1 = lampFactory.Create();
        lamp1.transform.SetParent(parent);
        lamp1.transform.localPosition = new Vector3(1, 0.5f, 0);
        lamp1.transform.rotation = new Quaternion(0, 0, 0, 1);
        lamp1.transform.localScale = new Vector3(1, 1, 1);

        var lamp2 = lampFactory.Create();
        lamp2.transform.SetParent(parent);
        lamp2.transform.localPosition = new Vector3(-1, 0.5f, 0);
        lamp2.transform.rotation = new Quaternion(0, 180, 0, 1);
        lamp2.transform.localScale = new Vector3(1, 1, 1);
    }


    public void BuildTree(Vector3 position, Transform parent)
    {
        var tree = treeFactroy.Create();
        tree.transform.SetParent(parent);
        tree.transform.localPosition = position;
        tree.transform.rotation = new Quaternion(0, 0, 0, 1);
        tree.transform.localScale = new Vector3(1, 1, 1);
    }

    public void BuildCars(Transform parent)
    {
        var car = carFactory.Create();
        car.transform.SetParent(parent);
        car.transform.localPosition = new Vector3(Randomize.Next(-0.4f, 0.4f), 0.5f, Randomize.Next(1, -1));
    }

    public void BuildCharacters(Transform parent)
    {
        var character = characterFactory.Create();
        character.transform.SetParent(parent);
        character.transform.localPosition = new Vector3(Randomize.Next(-0.85f, 0.85f), 0.90f, Randomize.Next(1, -1));
    }
}
