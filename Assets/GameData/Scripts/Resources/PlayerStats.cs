using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player",menuName ="Create New Player settings")]
public class PlayerStats : ScriptableObject
{
    public float maxSize;
    public float minSize;
    public float sizeDecreaseSpeed;
    public float speed;
}
