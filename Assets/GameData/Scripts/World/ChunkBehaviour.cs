using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{
    [SerializeField] Transform envObjects;
    [SerializeField] EnvironmentObject tree;
    EnvObjFactory trees;
    private void Start()
    {
        trees = new EnvObjFactory(tree);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z-(int)(100*Time.deltaTime)/8f);
        if (transform.position.z <= -16)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            ReInitialize();
        }
    }

    void ReInitialize()
    {
        for (int i = 0; i < envObjects.childCount; i++)
        {
            var child = envObjects.GetChild(i);
            child.gameObject.SetActive(false);
            child.transform.SetParent(null);
        }
        InitializeEnv();
    }

    void InitializeEnv()
    {
        var tree = trees.Create();
        tree.transform.SetParent(envObjects);
        tree.transform.localPosition = new Vector3(Randomize.Next(3, -3), 0.5f, 0);
    }
}
