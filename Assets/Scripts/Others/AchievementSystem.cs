using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.bullet;
using System;
using BattleTank.Tank;

public class AchievementSystem : MonoBehaviour
{

    private int tanksDestoryed = 0;
    private int BulletsFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyService.Instance.onDeathEvent += AS_OnDeathEvent;
        BulletService.Instance.onBulletFire += AS_onBulletFire;
        
    }

    private void AS_onBulletFire(TankView tankView)
    {
        BulletsFired += 1;
        if(BulletsFired == 100)
        {
            Debug.Log("Acheivement Unlocked: " + BulletsFired + " Bullets fired!!!");
        }
    }

    private void AS_OnDeathEvent()
    {
        tanksDestoryed += 1;
        if(tanksDestoryed == 4)
        {
            Debug.Log("Acheivement Unlocked: Number of tanks destoryed are " + tanksDestoryed);
        }
    }

}
