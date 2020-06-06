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

            EnemyController enemyController = GetItem();
            InitItem(enemyController);
            return enemyController;
        }

        public override void InitItem(EnemyController enemyController)
        {
            enemyController.EnemyView.initializeHealth(enemyController);
        }

        protected override EnemyController CreateItem()
        {
            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab);
            return enemyController;
        }

    }

}
