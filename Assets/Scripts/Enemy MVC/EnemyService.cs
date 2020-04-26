using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonosingletonGeneric<EnemyService>
    {

        private EnemyModel enemyModel;
        public EnemyView enemyView;
        public EnemyController enemyController;

        public List<EnemyController> enemyList = new List<EnemyController>();

        public event Action onDeathEvent;

        public EnemyTankScriptableObject enemyTankScriptableObject;

        private void Start()
        {

            Debug.Log(enemyList.Count + " Enemy service script");
        }

        public EnemyController CreateEnemyTank()
        {
            enemyModel = new EnemyModel(enemyTankScriptableObject);

            enemyController = new EnemyController(enemyModel, enemyView);

            enemyList.Add(enemyController);

            SceneService.Instance.followEnemey();
            Debug.Log(enemyList.Count + " Updated enemy count!!!");
            return enemyController;

        }

        public void DestroyEnemyTank(EnemyController enemyController)
        {
            onDeathEvent?.Invoke();
            enemyController.DestroyStuff();
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] == enemyController)
                {
                    enemyList.Remove(enemyController);
                }
            }
            enemyController = null;
           
            

        }


    }

}