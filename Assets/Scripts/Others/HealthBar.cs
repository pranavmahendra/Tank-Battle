using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleTank.EnemyTank;
using BattleTank.bullet;
using BattleTank.Tank;
using System;

public class HealthBar : MonosingletonGeneric<HealthBar>
{
    //Maxvalue equal to scriptable object model health.
    //value updated every frame on taking damage from player tank.

    public Slider slider;

    public EnemyView enemyView;
    //public BulletView bulletView;

    public float maxValue;
    public float value;

    private void Start()
    {

        slider = GetComponent<Slider>();

        EnemyService.Instance.onDamageTaken += healthbar_onDamageTaken;



    }

    private void Update()
    {


    }

    private void healthbar_onDamageTaken()
    {
        value -= 50;
        slider.value = value;
    }

   

    public void followHealthEnemey()
    {
        foreach (EnemyController enemyController in EnemyService.Instance.enemyList)
        {
            this.enemyView = enemyController.EnemyView;

            this.maxValue = enemyView.enemyController.getModel().Health;

            this.value = this.maxValue;

             
        }
    }

    //public void followBullet()
    //{
    //    foreach (BulletController bulletController in BulletService.Instance)
    //    {
    //        this.bulletView = bulletController.BulletView;
    //    }
    //}



}
