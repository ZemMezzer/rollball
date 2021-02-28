using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : PoolObject
{
    private Stack<T> pool;
    private readonly T _obj;


    public ObjectPool(T obj)
    {
        pool = new Stack<T>();
        _obj = obj;
    }

    public T Get()
    {
        var obj = pool.Count > 0 ? pool.Pop() : UnityEngine.Object.Instantiate(_obj);
        obj.transform.position.Normalize();
        obj.transform.rotation.Normalize();
        obj.gameObject.SetActive(true);
        obj.onDisable = () => 
        {
            Put(obj);
        };
        return obj;
    }

    public void Put(T _Obj)
    {
        _Obj.gameObject.SetActive(false);
        pool.Push(_Obj);
    }
}