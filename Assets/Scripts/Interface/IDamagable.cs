using System;
using UnityEngine;
using BattleTank.EnemyTank;

//This needs to take a tankID.
public interface IDamagable
{
     void TakeDamage(BulletType bullettype, int damage);

    
}


