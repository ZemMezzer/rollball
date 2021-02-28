using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float totalScore { get; set; }

    public void IncScore(float score)
    {
        totalScore += score;
    }

    public float GetScore()
    {
        return totalScore;
    }
}
