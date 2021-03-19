using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private static int score;


    private void HandleScore()
    {
        scoreText.text = "Score: " + score;
    }

    public static void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }


    private void Update()
    {
        HandleScore();
    }
}