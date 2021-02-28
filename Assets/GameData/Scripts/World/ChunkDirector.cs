using UnityEngine;

public class ChunkDirector
{
    ChunkBuilder _builder;
    public ChunkDirector(ChunkBuilder builder)
    {
        _builder = builder;
    }

    public void GenerateChunk(Transform parent)
    {
        _builder.BuildBuilding(new Vector3(Randomize.Next(-3, 3), 0.5f, 0), parent);
        _builder.BuildLamps(parent);
        _builder.BuildTree(new Vector3(Randomize.Next(-3, 3), 0.5f, Randomize.Next(-3, 3)),parent);
        _builder.BuildCars(parent);
        _builder.BuildCharacters(parent);
    }
}
