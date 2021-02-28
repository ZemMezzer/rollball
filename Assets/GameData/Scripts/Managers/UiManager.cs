using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] ScoreDisplay scoreDisplay;
    [SerializeField] Text scoreText;
    public void ShowScore(float score)
    {
        scoreDisplay.score = score;
        var _scoreDisplay = Instantiate(scoreDisplay,transform);
        _scoreDisplay.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString();
    }
}
