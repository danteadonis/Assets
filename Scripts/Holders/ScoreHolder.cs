using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Highscore : " + (PlayerPrefs.GetInt("Highscore")).ToString();
    }

    public void ScoreAdder(int gottenScore)
    {
        score += gottenScore;
    }
}
