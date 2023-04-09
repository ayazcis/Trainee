using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public float gameScore = 0f;
    public Image scoreBar;
    [SerializeField] float incScoreAmount=0.05f;
    [SerializeField] float decScoreAmount=0.05f;
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
            gameScore -= decScoreAmount;
            scoreBar.fillAmount = gameScore;
    }
    public void increaseScore()
    {
            gameScore += incScoreAmount;
            scoreBar.fillAmount = gameScore;
    }
}
