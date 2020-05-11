using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;
using UnityEngine.UI;
using BattleTank.bullet;
using TMPro;

public class Score : MonoBehaviour
{

    private TextMeshProUGUI tankDestroyText;
  
    
    private int score = 0;
    

    void Start()
    {

        EnemyService.Instance.onDeathEvent += Score_OnDeathEvent;
    
        tankDestroyText = GetComponent<TextMeshProUGUI>();
       
    }

    void Update()
    {
        
    }

    private void Score_OnDeathEvent()
    {
        score += 1;
        tankDestroyText.text = "Tanks Destroyed: " + score;
    }

    private void OnDestroy()
    {
        EnemyService.Instance.onDeathEvent -= Score_OnDeathEvent;
    }


}
