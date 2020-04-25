using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI UIText;
    private int score = 0;

    void Start()
    {
        EnemyService.Instance.onDeathEevnt += Score_OnDeathEvent;
        UIText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }


    private void Score_OnDeathEvent()
    {
        score += 1;
        UIText.text = "Number of tanks destroyed: " + score;
    }

}
