using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.EnemyTank
{
    public class ServicePoolEnemy : ServicePool<EnemyController>
    {
        private EnemyModel enemyModel;
        private EnemyView enemyPrefab;

        public EnemyController GetEnemyTank(EnemyModel enemyModel, EnemyView enemyPrefab)
        {
            this.enemyModel = enemyModel;
            this.enemyPrefab = enemyPrefab;

            return GetItem();
        }


        protected override EnemyController CreateItem()
        {
            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab);
            return enemyController;
        }

    }

}
