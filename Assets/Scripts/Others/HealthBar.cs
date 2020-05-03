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

    public Slider enemySlider;
    public Slider playerSlider;

    public EnemyView enemyView;
    public TankView tankView;
    public BulletView bulletView;

    private float damage;


    private void Start()
    {

    

        EnemyService.Instance.onDamageTaken += healthbar_onDamageTaken;

        TankService.Instance.onDamageTaken += healthbar_damageEvent;

    }

    private void healthbar_damageEvent()
    {
        playerSlider.value -= damage;

    }

    private void healthbar_onDamageTaken()
    {
        //Replace 50 with the bullet damage amount.
        enemySlider.value -= damage;
       

    }

   

    public void followHealthEnemey()
    {
        foreach (EnemyController enemyController in EnemyService.Instance.enemyList)
        {
            this.enemyView = enemyController.EnemyView;
            enemySlider.maxValue = enemyView.enemyController.EnemyModel.Health;
            enemySlider.value = enemySlider.maxValue;
        }
    }

    public void followBullet()
    {
        foreach (BulletController bulletController in BulletService.Instance.bulletsCreated)
        {
            this.bulletView = bulletController.BulletView;

            damage = bulletView.bulletController.BulletModel.Damage;
        }
    }

    public void followHealthPlayer()
    {
        this.tankView = TankService.Instance.tankLists[0].TankView;
        playerSlider.maxValue = tankView.tankController.TankModel.Health;
        playerSlider.value = playerSlider.maxValue;

    }



}
