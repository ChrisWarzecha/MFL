﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIscoreUpdater : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTextTone;
    
    [SerializeField] private TextMeshProUGUI scoreTextTtwo;
    

    private void Awake()
    {
        //scoreTextTone = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        //scoreTextTtwo = transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
       MFLEventManager.current.OnGoalScored += UpdateScore;
       //InitScore();
    }

    private void UpdateScore(int indexTeamScoredOn)
    {
        StartCoroutine(DelayUpdateScore(0.2f, indexTeamScoredOn));
        
    }

    private IEnumerator DelayUpdateScore(float delaytime, int indexTeamScoredOn)
    {
        yield return new WaitForSeconds(delaytime);
        
        Vector2 scoreCount = MFLScoreManager.current.GetScoreCount();
        
        if (indexTeamScoredOn == 1)
        {
            //scoreCount.y += 1;
            scoreTextTtwo.text = scoreCount.y.ToString();
        }

        if (indexTeamScoredOn == 2)
        {
            //scoreCount.x += 1;
            scoreTextTone.text = scoreCount.x.ToString();
        }
    }
    
    
    
    
    private void InitScore()
    {
        scoreTextTone.text = 0.ToString();
        
        scoreTextTtwo.text = 0.ToString();
    }
    
    
    
    
}
