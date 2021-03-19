using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private static int score;

    
    public static ScoreManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


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