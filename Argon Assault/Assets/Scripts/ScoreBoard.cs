using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public TMP_Text scoreText;
    
    private void Start() {
        scoreText.GetComponent<TMP_Text>().text = "";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.GetComponent<TMP_Text>().text = score.ToString();
    }
}
