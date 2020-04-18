using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        public EnemyController enemyController;
  
        private Enemeystate currentState;

        [SerializeField]
        public IdleState idleState;
        [SerializeField]
        public EnemyPatroling patrolingState;

        [SerializeField]
        private Enemeystate startingState;

        private void Start()
        {
            ChangeState(startingState);
        }

        private void Update()
        {
            //_enemyController.EnemyZMovement();
        }

        public void initialize(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        //Destroy enemy on collision with bullet.

        public void TakeDamage(BulletType bullettype, int damage)
        {
            Debug.Log("Taking damage " + damage);
            enemyController.ApplyDamage(damage);
        }

        public void ChangeState(Enemeystate newState)
        {
            if (currentState != null)
            {
                currentState.OnExitState();
            }

            currentState = newState;

            currentState.OnStateEnter();
        }

    }
}
