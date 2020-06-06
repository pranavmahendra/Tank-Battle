using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

namespace BattleTank.EnemyTank
{
    public class IdleState : Enemeystate
    {
        private Transform playerPos;


        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.Agent.speed = 0;
            //Debug.Log("Tank has entered idle state");
        }

        public override void OnExitState()
        {
            base.OnExitState();

            //Debug.Log("Tank has exited idle state");
        }

        private void Update()
        {

            enemyView.transform.LookAt(playerPos.position);

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.GetComponent<TankView>() != null)
            {
                GameObject player = other.gameObject;
                Transform goal = player.transform;
                this.playerPos = goal;
                enemyView.ChangeState(enemyView.idleState);


            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.ChangeState(enemyView.fixedPathState);
                
            }
        }




    }
}

