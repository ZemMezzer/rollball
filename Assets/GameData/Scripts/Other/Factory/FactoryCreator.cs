using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryCreator : MonoBehaviour
{
    protected abstract PoolObject CreateProduct();
    
    /// <summary>
    /// Создает объект
    /// </summary>
    /// <param name="transform">Transform созданного объекта</param>
    public PoolObject Create()
    {
        return CreateProduct();
    }
}
