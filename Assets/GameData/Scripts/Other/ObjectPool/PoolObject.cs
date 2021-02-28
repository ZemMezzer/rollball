using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public System.Action onDisable;
    protected virtual void OnDisable()
    {
        onDisable?.Invoke();
    }
}
