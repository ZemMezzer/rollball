using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyableObject : EnvironmentObject
{
    [SerializeField] List<Transform> parts;
    List<Vector3> partsStartPos = new List<Vector3>();

    private void Start()
    {
        foreach(Transform _parts in parts)
        {
            partsStartPos.Add(_parts.position);
        }
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().Eat(stats.objScore);
            StartCoroutine(PartsEat(collision.transform));
        }
    }

    IEnumerator PartsEat(Transform player)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        transform.SetParent(player);
        transform.DOLocalMove(new Vector3(0, 0, 0), 1f);
        foreach (Transform part in parts)
        {
            part.GetComponent<BoxCollider>().enabled = false;
            part.DOLocalMove(new Vector3(0, 0, 0), 1f);
            part.DOScale(new Vector3(0, 0, 0), 3f);
        }
        yield return new WaitForSecondsRealtime(3f);
        transform.SetParent(null);
        for(int i = 0; i < parts.Count; i++)
        {
            parts[i].position = partsStartPos[i];
            parts[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            parts[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
