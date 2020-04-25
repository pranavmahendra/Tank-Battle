using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank.EnemyTank
{
    public class EnemyController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView EnemyPrefab)
        {
            EnemyModel = enemyModel;

            EnemyView = GameObject.Instantiate<EnemyView>(EnemyPrefab);

            EnemyView.initialize(this);

        }

        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }

        

        public EnemyModel getModel()
        {
            return EnemyModel;
        }

        public void EnemyZMovement()
        {
            EnemyView.transform.Translate(new Vector3(0f, 0f, 1f) * EnemyModel.Speed * Time.deltaTime);
        }

        //Set position of enemy.
        public void setPositionEnemy(Vector3 position, Quaternion quaternion)
        {
            EnemyView.transform.position = position;
            EnemyView.transform.rotation = quaternion;
        }

        //Damage
        public void ApplyDamage(int damage)
        {
            if (EnemyModel.Health - damage <= 0)
            {
                //Destroy function being called from service.
                EnemyService.Instance.DestroyEnemyTank(this);

            }
            else
            {
                EnemyModel.Health -= damage;
                Debug.Log("Enemy took damage " + EnemyModel.Health);
            }
        }
        
        public void DestroyStuff()
        {
            EnemyModel.modelDestroy(getModel());
            EnemyView.enemyDestroyView(this.EnemyView);
 
        }

    }

}
