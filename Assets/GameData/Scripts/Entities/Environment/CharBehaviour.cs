using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBehaviour : EnvironmentObject
{
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }
}
