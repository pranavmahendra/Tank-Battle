using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyModel
    {
        public EnemyModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            this.EnemyType = enemyTankScriptableObject.enemyType;
            this.Speed = enemyTankScriptableObject.speed;
            this.Health = enemyTankScriptableObject.health;
        }

        public EnemyType EnemyType { get; }
        public float Speed { get; }
        public float Health { get; set; }
    }

}
