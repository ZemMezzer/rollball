using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] List<ChunkBehaviour> chunks;
    [SerializeField] EnvironmentObject tree;
    [SerializeField] EnvironmentObject smallBuilding;
    [SerializeField] EnvironmentObject bigBuilding;
    [SerializeField] EnvironmentObject lamp;
    [SerializeField] EnvironmentObject character;
    [SerializeField] EnvironmentObject car;

    void Start()
    {
        ChunkDirector director = new ChunkDirector(new ChunkBuilder(tree, smallBuilding, bigBuilding, lamp, character,car));
        foreach(ChunkBehaviour chunk in chunks)
        {
            chunk.reInitialize = () =>
            {
                for(int i = 0; i < chunk.envObjectsParent.childCount; i++)
                {
                    var _chunk = chunk.envObjectsParent.GetChild(i);
                    _chunk.SetParent(null);
                    _chunk.gameObject.SetActive(false);
                }
                director.GenerateChunk(chunk.envObjectsParent);
            };
        }
    }
}
