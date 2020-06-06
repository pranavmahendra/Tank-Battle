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

    public Image playerSlider;
    public Image enemySlider;

    private float StartEnemyHealth;
    private float EnemyHealth;
 
    private float StartPlayerHealth;
    private float PlayerHealth;
  

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
        //playerSlider.value -= damage;
        PlayerHealth -= damage;

        playerSlider.fillAmount = PlayerHealth / StartPlayerHealth;

    }


    private void healthbar_onDamageTaken()
    {
        //Replace 50 with the bullet damage amount.
        EnemyHealth -=  damage;
        enemySlider.fillAmount = EnemyHealth / StartEnemyHealth;
       

    }

   

    public void followHealthEnemey()
    {
        foreach (EnemyController enemyController in EnemyService.Instance.enemyList)
        {
            this.enemyView = enemyController.EnemyView;
            enemySlider = enemyView.sliderEnemyView;
            StartEnemyHealth = enemyView.enemyController.EnemyModel.Health;
            EnemyHealth = StartEnemyHealth;

            enemySlider.fillAmount = EnemyHealth / StartEnemyHealth;
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

        playerSlider = tankView.sliderPlayerView;
        StartPlayerHealth = tankView.tankController.TankModel.Health;
        PlayerHealth = StartPlayerHealth;

        playerSlider.fillAmount = PlayerHealth / StartPlayerHealth;


    }

}
