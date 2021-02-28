using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PlayerController player;

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] UiManager uiManager;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player.scoreInc = (score) =>
        {
            scoreManager.IncScore(score);
            uiManager.ShowScore(score);
            uiManager.UpdateScore(scoreManager.GetScore());

        };
    }

    void ScoreIncrease(float scoreInc)
    {

    }
}
