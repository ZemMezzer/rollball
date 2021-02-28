using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{
    public Action reInitialize;
    public Transform envObjectsParent;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z-(int)(100*Time.deltaTime)/8f);
        if (transform.position.z <= -16)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            reInitialize?.Invoke();
        }
    }
}
