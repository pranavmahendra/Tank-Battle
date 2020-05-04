using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BattleTank.Tank;

namespace BattleTank.EnemyTank
{
    public class EnemyService : MonosingletonGeneric<EnemyService>
    {

        private EnemyModel enemyModel;
        public EnemyView enemyView;
        public EnemyController enemyController;

        private ServicePoolEnemy servicePoolEnemy;

        //public TankView TankViewRef;

        public List<EnemyController> enemyList = new List<EnemyController>();

        public event Action onDeathEvent;
        public event Action onDamageTaken;

        public EnemyTankScriptableObject enemyTankScriptableObject;

        private void Start()
        {
            servicePoolEnemy = GetComponent<ServicePoolEnemy>();

            //for (int i = 0; i < 5; i++)
            //{
            //    EnemyController initialEnemies = CreateEnemyTank();
            //    //servicePoolEnemy.ReturnItem(initialEnemies);
            //}

            //Debug.Log(enemyList.Count + " Enemy service script");
        }



        public EnemyController CreateEnemyTank()
        {
            enemyModel = new EnemyModel(enemyTankScriptableObject);

            //enemyController = new EnemyController(enemyModel, enemyView);
            EnemyController enemyController = servicePoolEnemy.GetEnemyTank(enemyModel, enemyView);

            //Adding to enemyList
            enemyList.Add(enemyController);

            //Initialization 
            SceneService.Instance.followEnemey();
            HealthBar.Instance.followHealthEnemey();

            
            enemyController.Enable();
            //Debug
            //Debug.Log(enemyList.Count + " Updated enemy count!!!");
            //Debug.Log("MyID is " + enemyList[0].EnemyModel.myID);

            return enemyController;
          

        }

        public void DestroyEnemyTank(EnemyController enemyController)
        {
            onDeathEvent?.Invoke();
            
            enemyController.DestroyStuff();
            servicePoolEnemy.ReturnItem(enemyController);
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] == enemyController)
                {
                    enemyList.Remove(enemyController);
                }
            }
            enemyController = null;
        }

        public void onDamageEvent()
        {
            onDamageTaken?.Invoke();
        }


    }

}