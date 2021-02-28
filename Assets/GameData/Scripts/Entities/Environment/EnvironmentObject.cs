using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : PoolObject
{
    [SerializeField] protected EnvObjStats stats;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Eat());
            collision.GetComponent<PlayerController>().Eat(stats.objScore, transform);
        }
    }

    protected IEnumerator Eat()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 1f);
        transform.DOScale(new Vector3(0, 0, 0), 2f);
        yield return new WaitForSecondsRealtime(3);
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
    }
}
