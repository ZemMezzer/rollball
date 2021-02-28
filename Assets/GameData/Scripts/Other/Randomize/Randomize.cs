using UnityEngine;

public class Randomize
{
    public static float Next(float a, float b)
    {
        float rand = Random.Range(0, 100);
        if (rand < 50)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}
