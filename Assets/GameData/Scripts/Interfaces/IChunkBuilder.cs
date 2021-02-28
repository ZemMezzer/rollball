using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChunkBuilder
{
    void BuildTree(Vector3 position, Transform parent);

    void BuildLamps(Transform parent);

    void BuildBuilding(Vector3 position, Transform parent);

    void BuildCars(Transform parent);

    void BuildCharacters(Transform parent);
}
