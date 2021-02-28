using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjFactory : FactoryCreator
{
    ObjectPool<EnvironmentObject> envObjects;

    public EnvObjFactory(EnvironmentObject envObj)
    {
        envObjects = new ObjectPool<EnvironmentObject>(envObj);
    }

    protected override PoolObject CreateProduct()
    {
        return envObjects.Get();
    }
}
