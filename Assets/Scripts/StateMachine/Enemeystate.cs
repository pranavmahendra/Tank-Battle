using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    //[RequireComponent(typeof(EnemyView))]
    public class Enemeystate : MonoBehaviour
    {
        public EnemyView enemyView;

        private void Awake()
        {

            
        }

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        public virtual void OnExitState()
        {
            this.enabled = false;
        }

        public void Tick()
        {

        }

        public void followEnemey()
        {
            foreach (EnemyController enemyController in EnemyService.Instance.enemyList)
            {
                this.enemyView = enemyController.EnemyView;
            }
        }

    }

}
