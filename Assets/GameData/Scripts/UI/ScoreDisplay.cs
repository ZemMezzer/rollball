using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ScoreDisplay : MonoBehaviour
{
    [HideInInspector] public float score;
    [SerializeField] UnityEngine.UI.Text scoreText;

    IEnumerator Start()
    {
        yield return null;
        scoreText.text = score.ToString();
        transform.DOLocalMove(new Vector3(Randomize.Next(-300, 300), Randomize.Next(200, 300)), 3f);
        transform.DOScale(2, 3f);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
