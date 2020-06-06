using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using System;
using BattleTank.Tank;

public class AchievementSystem : MonosingletonGeneric<AchievementSystem>
{
    [HideInInspector]
    public int tanksDestoryed = 0;
    [HideInInspector]
    public int BulletsFired = 0;

    private TankView tankview;

    public event Action tankGoalReached;

    // Start is called before the first frame update
    void Start()
    {
        EnemyService.Instance.onDeathEvent += AS_OnDeathEvent;
        TankService.Instance.onBulletFire += AS_onBulletFire;
        
    }

    private void AS_onBulletFire()
    {
        BulletsFired += 1;
        if (BulletsFired == 100)
        {
            Debug.Log("Acheivement Unlocked: " + BulletsFired + " Bullets fired!!!");
        }
    }

    private void AS_OnDeathEvent()
    {
        tanksDestoryed += 1;
        if(tanksDestoryed == 5)
        {
            Debug.Log("Acheivement Unlocked: Number of tanks destoryed are " + tanksDestoryed);
            tankGoalReached?.Invoke();
        }
    }

    public void followPlayerAchievement()
    {
        this.tankview = TankService.Instance.tankLists[0].TankView;

    }
}
