using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public float gameScore = 0f;
    public Image scoreBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseScore()
    {
            gameScore -= 0.1f;
            scoreBar.fillAmount = gameScore;
    }
    public void increaseScore()
    {
            gameScore += 0.1f;
            scoreBar.fillAmount = gameScore;
    }
}
