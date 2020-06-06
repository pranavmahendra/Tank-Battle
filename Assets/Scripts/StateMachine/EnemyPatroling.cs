using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;

namespace BattleTank.EnemyTank
{
    public class EnemyPatroling : Enemeystate
    {
        public float speed = 2;
        private Transform PlayerPos;

        public override void OnStateEnter()
        {
            base.OnStateEnter();


            //Debug.Log("Enemy has entered patroling state");

        }

        public override void OnExitState()
        {
            base.OnExitState();

            //Debug.Log("Enemy has exit patroling state");
        }

        private void Update()
        {

            enemyView.transform.LookAt(PlayerPos.position);
            enemyView.transform.Translate(0, 0, speed * Time.deltaTime,Space.Self);



        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                GameObject player = other.gameObject;
                Transform goal = player.transform;
                this.PlayerPos = goal;
                enemyView.ChangeState(enemyView.patrolingState);

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {

                enemyView.ChangeState(enemyView.idleState);
            }
        }

    }

}
