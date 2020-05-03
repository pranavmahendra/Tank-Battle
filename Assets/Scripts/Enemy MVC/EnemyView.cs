using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;
using System;

namespace BattleTank.EnemyTank
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        public EnemyController enemyController;

        private Enemeystate currentState;

        public Transform enemyBarrelTip;
        public LayerMask rayMask;

        [SerializeField]
        public IdleState idleState;
        [SerializeField]
        public EnemyPatroling patrolingState;
        [SerializeField]
        public AttackState attackState;


        private void Start()
        {
            
            
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
            
          
            EnemyService.Instance.onDamageEvent();
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

        public void enemyDestroyView(EnemyView enemyView)
        {
            Destroy(enemyView.gameObject);
            enemyView = null;
        }

    }
}